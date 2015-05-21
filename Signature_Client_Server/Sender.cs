using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Signature_Client_Server
{
    class Sender
    {
        private CspParameters GetCryptoServiceProvider()
        {
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = "Receiver's Public Keys";
            csp.ProviderType = 1;
            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";
            return csp;
        }

        public string SetReceiverPublicKey(RSAParameters xmlpublic)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());
            rsa.ImportParameters(xmlpublic);
            rsa.PersistKeyInCsp = true;
            return rsa.ToXmlString(false);
         //   System.Console.Out.WriteLine("Imported RSA Public Key \n {0}", rsa.ToXmlString(false));
        }

    }
}
