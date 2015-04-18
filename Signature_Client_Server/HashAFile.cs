using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Signature_Client_Server
{
    class HashAFile
    {
        private string globalFilepath;

        public HashAFile(string Filepath)
        {
            globalFilepath = Filepath;
        }
        public byte[] HashFile()
        {
            byte[] hashbyte = { };

            if (false == File.Exists(globalFilepath))
                return hashbyte;
            try
            {
                
                FileStream fsSource = File.OpenRead(globalFilepath);
                HashAlgorithm hash = HashAlgorithm.Create();
                hashbyte = hash.ComputeHash(fsSource);
                fsSource.Close();
            }
            catch (Exception)
            {

            }
            return hashbyte;
        }

        public bool CreateHashFile(string Filepath)
        {

            if (true == File.Exists(Filepath))
                return false;

            try
            {

                FileStream fHash = File.Create(Filepath);

                byte[] hashbyte;
                hashbyte = HashFile();

                if (0 == hashbyte.Length)
                    return false;

                fHash.Write(hashbyte, 0, hashbyte.Length);

                fHash.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
