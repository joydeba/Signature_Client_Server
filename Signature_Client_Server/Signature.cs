using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Signature_Client_Server
{
    class Signature
    {
        RSACryptoServiceProvider globaLrsa;
        string globalHashAlgo;

        public static CspParameters GetCryptoServiceProvider()
        {
            // Create the CspParameters object 
            CspParameters csp = new CspParameters();
            // Set the key container name that has the _rsa key pair
            csp.KeyContainerName = "temp Keys";
            //Set the CSP Provider Type PROV_RSA_FULL
            csp.ProviderType = 1;
            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;
            //Set the CSP Provider Name
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";
            return csp;
        }

        public Signature(string hashAlgo)
        {
            globaLrsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());
            globalHashAlgo = hashAlgo;
        }

        public byte[] Sign(byte[] hashvalue)
        {
            //Computes the signature for the specified hash value by encrypting it with the private key
            Sender sender_s = new Sender();
            RSAParameters xmlboth_r = sender_s.get_both_key(); 
            globaLrsa.ImportParameters(xmlboth_r);
            byte[] sign = globaLrsa.SignHash(hashvalue, CryptoConfig.MapNameToOID(globalHashAlgo)); //128 byte signature

            return sign;
        }

        public bool Validate(string file, byte[] sign)
        {
            HashAFile haf = new HashAFile(file);
            byte[] hash = haf.HashFile();
            bool test = globaLrsa.VerifyHash(hash, CryptoConfig.MapNameToOID(globalHashAlgo), sign);
            return test;
        }


    }
}
