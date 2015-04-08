using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using TextEncryption;

namespace Bob
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Bob : MarshalByRefObject
    {
        //Let us assume that both Bob and Alice 
        //use a known fixed mode and padding.
        static CipherMode _mode = CipherMode.CBC;
        static PaddingMode _pad = PaddingMode.PKCS7;

        //Also let us assume that both Bob and Alice
        //use a AES Symmetric Algorithm
        RijndaelManaged _aes;


        // This returns the CSP used by Bob
        private CspParameters GetCryptoServiceProvider()
        {
            // Create the CspParameters object 
            CspParameters csp = new CspParameters();

            // Set the key container name that has the RSA key pair
            csp.KeyContainerName = "Bob's Keys";

            //Set the CSP Provider Type PROV_RSA_FULL
            csp.ProviderType = 1;

            //Use default key container
            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;

            //Set the CSP Provider Name
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";

            return csp;
        }

        //This function is locally called to initialiase Bob's Key Container
        public void SetBobKeyPair(RSAParameters xmlprivate)
        {
            // Create the RSA CSP passing CspParameters object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());

            //Import the RSA key pair 
            rsa.ImportParameters(xmlprivate);

            //let us save the keys for future use.
            rsa.PersistKeyInCsp = true;

            System.Console.Out.WriteLine("Imported RSA Key Pair	\n {0}", rsa.ToXmlString(true));
        }

        //This function will be called remotely at the begining of the communication (First Part)
        //to fix the session key
        public void Envelope(byte[] envelope)//string envelope)
        {
            //Encoding
            Encoding ecode = new UnicodeEncoding();

            // Create the RSA CSP passing CspParameters object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());

            //Decrypt the Envelope with Bob's private key
            byte[] secretkey = rsa.Decrypt(/*ecode.GetBytes(envelope)*/envelope, false); //Don't use OAEP Padding

            //Conver the session key byte array to string
            string sessionKey = ecode.GetString(secretkey, 0, secretkey.Length);

            //break the session key into secret key and IV
            string sKey = sessionKey.Substring(0, 16);
            string sIV = sessionKey.Substring(16, 8);

            //Create a AES with the passed details
            _aes = new RijndaelManaged();
            _aes.Key = ecode.GetBytes(sKey);
            _aes.IV = ecode.GetBytes(sIV);
            _aes.Padding = _pad;
            _aes.Mode = _mode;
        }

        //This function will be called remotely to pass the messages (Second Part)
        public void Message(byte[] sMessage)
        {
            Console.Out.WriteLine("Message Received by Bob : {0}", new TextEncryption.TextEncryption(_aes).Decrypt(sMessage));
        }
    }

}
