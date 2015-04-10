using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Sign
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class DigitalSignatureWithRSA
    {
        //Create _rsa Asymmetric Algorithm
        RSACryptoServiceProvider _rsa;

        string _strHashAlgo;

        // This returns the CSP 
        private CspParameters GetCryptoServiceProvider()
        {
            // Create the CspParameters object 
            CspParameters csp = new CspParameters();

            // Set the key container name that has the _rsa key pair
            csp.KeyContainerName = "Gowri's Keys";

            //Set the CSP Provider Type PROV_RSA_FULL
            csp.ProviderType = 1;

            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;

            //Set the CSP Provider Name
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";

            return csp;
        }

        public DigitalSignatureWithRSA(string hashAlgo)
        {
            _rsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());
            _strHashAlgo = hashAlgo;
        }

        public byte[] Hash(string plaintext)
        {
            //Create SHA1 Hash algorithm
            HashAlgorithm hashAlgo = HashAlgorithm.Create(_strHashAlgo);

            //Encode the string into unicode bytes
            byte[] plaintextbyte = new UnicodeEncoding().GetBytes(plaintext);

            //Compute the hash
            byte[] hash = hashAlgo.ComputeHash(plaintextbyte);
            //20 byte hash for SHA-1 
            //16 byte hash for MD5

            return hash;
        }

        public byte[] Sign(string plaintext)
        {
            //Compute the hash
            byte[] hash = Hash(plaintext);

            //Computes the signature for the specified hash value by encrypting it with the private key
            byte[] sign = _rsa.SignHash(hash, CryptoConfig.MapNameToOID(_strHashAlgo)); //128 byte signature

            return sign;
        }

        public bool Validate(string plaintext, byte[] sign)
        {

            //Compute the hash
            byte[] hash = Hash(plaintext);

            //Verfiy the signature
            bool test = _rsa.VerifyHash(hash, CryptoConfig.MapNameToOID(_strHashAlgo), sign);

            return test;
        }
    }

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class DigitalSignatureWithDSA
    {
        //Create _rsa Asymmetric Algorithm
        DSACryptoServiceProvider _rsa;

        string _strHashAlgo;

        // This returns the CSP 
        private CspParameters GetCryptoServiceProvider()
        {
            // Create the CspParameters object 
            CspParameters csp = new CspParameters();

            // Set the key container name that has the _rsa key pair
            csp.KeyContainerName = "Gowri's Keys";

            //Set the CSP Provider Type PROV_DSS_DH
            csp.ProviderType = 13;

            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;

            //Set the CSP Provider Name
            csp.ProviderName = "Microsoft Enhanced DSS and Diffie-Hellman Cryptographic Provider";

            return csp;
        }

        public DigitalSignatureWithDSA(string hashAlgo)
        {
            _rsa = new DSACryptoServiceProvider(GetCryptoServiceProvider());
            _strHashAlgo = hashAlgo;
        }

        public byte[] Hash(string plaintext)
        {
            //Create SHA1 Hash algorithm
            HashAlgorithm hashAlgo = HashAlgorithm.Create(_strHashAlgo);

            //Encode the string into unicode bytes
            byte[] plaintextbyte = new UnicodeEncoding().GetBytes(plaintext);

            //Compute the hash
            byte[] hash = hashAlgo.ComputeHash(plaintextbyte);

            return hash;
        }

        public byte[] Sign(string plaintext)
        {
            //Compute the hash
            byte[] hash = Hash(plaintext);

            //Computes the signature for the specified hash value by encrypting it with the private key
            byte[] sign = _rsa.CreateSignature(hash);

            return sign;
        }

        public bool Validate(string plaintext, byte[] sign)
        {
            //Compute the hash
            byte[] hash = Hash(plaintext);

            //Verfiy the signature
            bool test = _rsa.VerifySignature(hash, sign);

            return test;
        }
    }
    class TestDigitalSignature
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            TestRSA();
            TestDSA();
        }
        static void TestRSA()
        {
            DigitalSignatureWithRSA sign1 = new DigitalSignatureWithRSA("SHA1");

            //This is the test that is going to be signed
            string plaintext = "Oops! I did it again.....";

            //Get the signature
            byte[] signature = sign1.Sign(plaintext);

            DigitalSignatureWithRSA sign2 = new DigitalSignatureWithRSA("SHA1");

            //Validate it
            bool fvalid = sign2.Validate(plaintext, signature);

            System.Console.Out.WriteLine("Signature is valid : " + fvalid);

            DigitalSignatureWithRSA sign3 = new DigitalSignatureWithRSA("MD5");


            //Get the signature
            signature = sign3.Sign(plaintext);

            DigitalSignatureWithRSA sign4 = new DigitalSignatureWithRSA("MD5");

            //Validate it
            fvalid = sign2.Validate(plaintext, signature);

            System.Console.Out.WriteLine("Signature is valid : " + fvalid);

        }
        static void TestDSA()
        {
            DigitalSignatureWithDSA sign1 = new DigitalSignatureWithDSA("SHA1");

            //This is the test that is going to be signed
            string plaintext = "Oops! I did it again.....";

            //Get the signature
            byte[] signature = sign1.Sign(plaintext); //40 byte signature

            DigitalSignatureWithDSA sign2 = new DigitalSignatureWithDSA("SHA1");

            //Validate it
            bool fvalid = sign2.Validate(plaintext, signature);

            System.Console.Out.WriteLine("Signature is valid : " + fvalid);

            //Following with throw exceptions as DSA works with SHA only	
            /*
			
                DigitalSignatureWithDSA sign3 = new DigitalSignatureWithDSA("MD5");

		
                //Get the signature
                signature = sign3.Sign(plaintext);

                DigitalSignatureWithDSA sign4 = new DigitalSignatureWithDSA("MD5");

                //Validate it
                fvalid = sign2.Validate(plaintext,signature);

                System.Console.Out.WriteLine( "Signature is valid : " + fvalid);
            */

        }
    }
}
