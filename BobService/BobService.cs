using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace BobService
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class BobService
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("BobService.Main(): Server started");

            RemotingConfiguration.Configure("BobService.exe.config");

            Console.WriteLine("Press <return> to exit");
            Console.ReadLine();
        }
    }
}
