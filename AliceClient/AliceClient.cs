using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;


namespace AliceClient
{
    class AliceClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            String filename = "AliceClient.exe.config";
            
            RemotingConfiguration.Configure(filename);

            //Create Bob remotely
            Bob.Bob bob = new Bob.Bob();
            System.Console.Out.WriteLine("Bob created remotely");

            //Create Locally Alice
            Alice.Alice alice = new Alice.Alice();
            System.Console.Out.WriteLine("Alice created locally");

            //let Alice create the session key and envelope it 
            byte[] digitalEnvelope = alice.Envelope();
            System.Console.Out.WriteLine("Alice create envelope :" + digitalEnvelope);

            //send the enveloped session key to Bob
            bob.Envelope(digitalEnvelope);
            System.Console.Out.WriteLine("Digital Envelope send to Bob\n\n");


            System.Console.Out.WriteLine("Enter the message that alice should send to Bob.");
            System.Console.Out.WriteLine("To stop sending any mesasge just press <enter>:");
            do
            {
                System.Console.Out.Write("Message :");
                string plaintext = Console.ReadLine();
                if (plaintext.Length == 0)
                    break;

                //Alice will encrypt it with the session key that it exchanged with Bob
                byte[] ciphertextbyte = alice.Message(plaintext);

                //send the cipher text to Bob
                bob.Message(ciphertextbyte);

            } while (true);

        }
    }

}
