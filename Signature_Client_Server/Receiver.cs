using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace Signature_Client_Server
{
    class Receiver
    {

        public string SetSenderPublicKey(RSAParameters xmlpublic)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(Signature.GetCryptoServiceProvider());
            rsa.ImportParameters(xmlpublic);
            rsa.PersistKeyInCsp = true;
            return rsa.ToXmlString(false);
            //   System.Console.Out.WriteLine("Imported RSA Public Key \n {0}", rsa.ToXmlString(false));
        }



    }
}
