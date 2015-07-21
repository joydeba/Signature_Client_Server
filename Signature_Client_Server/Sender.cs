using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Signature_Client_Server
{
    class Sender
    {
        public static RSAParameters both_key;



        public string SetSenderKeyPair(RSAParameters xmlprivate)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(Signature.GetCryptoServiceProvider());
            both_key = xmlprivate;
            rsa.ImportParameters(xmlprivate);
            rsa.PersistKeyInCsp = true;
            return rsa.ToXmlString(true);
            //    System.Console.Out.WriteLine("Imported RSA Key Pair	\n {0}", rsa.ToXmlString(true));
        }

        public RSAParameters get_both_key()
        {
            return both_key;
        }


    }
}
