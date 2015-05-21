using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace Signature_Client_Server
{
    class Receiver
    {
        private CspParameters GetCryptoServiceProvider()
        {
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = "Receiver's Keys";
            csp.ProviderType = 1;
            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";
            return csp;
        }

        public void SetBobKeyPair(RSAParameters xmlprivate)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(GetCryptoServiceProvider());
            rsa.ImportParameters(xmlprivate);
            rsa.PersistKeyInCsp = true;

        //    System.Console.Out.WriteLine("Imported RSA Key Pair	\n {0}", rsa.ToXmlString(true));
        }


    }
}
