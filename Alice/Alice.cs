using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using TextEncryption;

namespace Alice
{
    public class Alice : MarshalByRefObject
    {
        //Let us assume that both Bob and Alice 
        //use a known fixed mode and padding.
        static CipherMode _mode = CipherMode.CBC;
        static PaddingMode _pad = PaddingMode.PKCS7;

        //Also let us assume that both Bob and Alice
        //use a AES Symmetric Algorithm
        RijndaelManaged _aes;


        // This returns the CSP used by Alice
        private CspParameters GetCryptoServiceProvider()
        {
            // Create the CspParameters object 
            CspParameters csp = new CspParameters();

            // Set the key container name that has the RSA key pair
            csp.KeyContainerName = "Bob's Public Keys";

            //Set the CSP Provider Type PROV_RSA_FULL
            csp.ProviderType = 1;

            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;

            //Set the CSP Provider Name
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";

            return csp;
        }

        //This function is locally called to initialiase Bob's Key Container
        public void SetBobPublicKey(RSAParameters xmlpublic)
        {
            // Create the RSA CSP passing CspParameters object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());

            //Import the RSA public key 
            rsa.ImportParameters(xmlpublic);

            //let us save the keys for future use.
            rsa.PersistKeyInCsp = true;

            System.Console.Out.WriteLine("Imported RSA Public Key \n {0}", rsa.ToXmlString(false));
        }

        //This function will be called at the begining of the communication (First Part)
        //to fix the session key
        public byte[] Envelope()
        {
            //Encoding
            Encoding ecode = new UnicodeEncoding();

            // Create the RSA CSP passing CspParameters object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());

            //Create a new AES Session Key 
            _aes = new RijndaelManaged();
            _aes.Padding = _pad;
            _aes.Mode = _mode;

            //we need to send both the secret key(128 bits) and the IV(128 bits)
            string sKey = ecode.GetString(_aes.Key, 0, _aes.Key.Length); //encoded to 16 character unicode string
            string sIV = ecode.GetString(_aes.IV, 0, _aes.IV.Length);//encoded to 8 character unicode string

            //Concatinate the secret key and IV to build a session key
            StringBuilder sesskeyBuilder = new StringBuilder(sKey);
            sesskeyBuilder.Append(sIV);

            string sessionkey = sesskeyBuilder.ToString(); //24 chacacter unicode string

            //Envelope the Session key with Bob's Public Keys
            byte[] envelope = rsa.Encrypt(ecode.GetBytes(sessionkey), false);

            return envelope;
        }

        //This function will pass the messages to Bob(Second Part)
        public byte[] Message(string message)
        {
            return new TextEncryption.TextEncryption(_aes).Encrypt(message);
        }
    }
}
