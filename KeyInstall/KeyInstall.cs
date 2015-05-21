using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace KeyInstall
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class KeyInstall
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            string xmlRSAKeyPair = "<RSAKeyValue><Modulus>22BoUo2P28KglLh8G5gyOPXHFYDjF3i+KTNoE3wiSj+egBzM44Y+Ap4eeNQaBPrSp7PmGrLQp6sjBF1817llvCqTnk18V+EdMsJ5hUT5SzEFwCcPqSDH9Ns1wM/hP541RCTe+E53mAnovVKPoS4en+SnCnp2Lxnne01B4an8PM0=</Modulus><Exponent>AQAB</Exponent><P>8jIknnZvylSfuJE/XIiWVAPmD1z6T7cu53rBGVyXmIVfmqqC20f6IISERd1cvhrOLc+5IIUYt5uPXW1LHkYjTw==</P><Q>5+FPfr2qHrdZprpL7qaJUTw3N5JnBYzG+lNC/ZEk7qVWddVCQjaKfE8D7M8sYeT5o+WnoW+CHh83daBRrx3HIw==</Q><DP>yPBLK2Ft7Dr7bOCs5fO4bSny5Ioqbpq3gnt427bTW0pEgIi5Gn8ECZiIOYKnoF2S87UkjdN/J04bytKTgSGFxw==</DP><DQ>0XK9+JBfIuGgtC4guk9pR5xpj+PI9MVlUeV1ZE7/miR0RXk9IUvcqU5CEFxODZrjN30QfoyXbpfp43DNd60hGw==</DQ><InverseQ>eZ0h/wsZEhwUcprax89t3VEZfuACP2R8IGmvlOPQ89clxAR/twbF4aSPwoEiFJ8v0fgoceRQ8BP7S3CowhcWFw==</InverseQ><D>AKtiph3Yeos1gj6t4kesn4/gc6hZCRFNQ0Ls5mJSmHdpPGraFTerqMZiwWukSK+bRPe/lAVHrbtP+Atw/heKv+7O9VIAZnADXXF4CnNAsrFSgRS+BHoShQytzF2kIJpJZfWZ9MYJfI2wquDWCJTCc1ZbdnEhtBohKMvWrP8fV+E=</D></RSAKeyValue>";

            // Create the CspParameters object 
            CspParameters csp = new CspParameters();

            //Don't Set the key container name 
            //let us use memory based container
            //csp.KeyContainerName = "Bob's Public Keys";

            //Set the CSP Provider Type PROV_RSA_FULL
            csp.ProviderType = 1;

            //Set the CSP Provider Name
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";

            // Create the RSA CSP passing CspParameters object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);

            rsa.FromXmlString(xmlRSAKeyPair);

            System.Console.Out.Write("Is it Alice's m/c or Bob's m/c. Enter a for Alice and b for Bob :");
            int option = System.Console.In.Read();

            if (option == 'a')
            {
                Alice.Alice alice = new Alice.Alice();
                alice.SetBobPublicKey(rsa.ExportParameters(false));
                
            }
            else if (option == 'b')
            {
                Bob.Bob bob = new Bob.Bob();
                bob.SetBobKeyPair(rsa.ExportParameters(true));
            }
            else
                System.Console.Out.WriteLine("Incorrect option. Bye");

            
        }
    }
}
