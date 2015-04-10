using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace FileHash
{
    /// <summary>
    /// Summary description for FileHash.
    /// </summary>
    /*
    * This function suppreses the error messages.
    * For real programs this needs to be logged/displayed
    */
    public class FileHash
    {

        private string _SourceFilepath;

        public FileHash()
        {

        }
        public FileHash(string SourceFilepath)
        {
            _SourceFilepath = SourceFilepath;
        }

        public string SourceFile
        {
            get
            {
                return _SourceFilepath;
            }

            set
            {
                _SourceFilepath = value;
            }
        }

        /*
         * Generic function 
         */
        public byte[] HashFile(string _skey)
        {
            //if Key is passed then call keyed hash function
            if (0 != _skey.Length)
            {
                byte[] key = new UnicodeEncoding().GetBytes(_skey);
                return HashFile(key);
            }

            //if Key is not passed then call simple hash function
            return HashFile();
        }

        /*
         *	Simple Hashing
         * 
         */
        public byte[] HashFile()
        {
            byte[] hashbyte = { };

            //Ensure that the source file exists
            if (false == File.Exists(_SourceFilepath))
                return hashbyte;

            try
            {
                //Open the Source file
                FileStream fsSource = File.OpenRead(_SourceFilepath);

                //Create the default hash algorithm
                HashAlgorithm hash = HashAlgorithm.Create();

                //Compute the hash
                hashbyte = hash.ComputeHash(fsSource);

                //close the streams
                fsSource.Close();
            }
            catch (Exception)
            {

            }

            return hashbyte;
        }

        /*
         *	Keyed Hashing
         * 
         */
        public byte[] HashFile(byte[] _key)
        {
            byte[] hashbyte = { };

            //Ensure that the source file exists
            if (false == File.Exists(_SourceFilepath))
                return hashbyte;

            try
            {
                //Open the Source file
                FileStream fsSource = File.OpenRead(_SourceFilepath);

                //Create the default hash algorithm
                KeyedHashAlgorithm hash = KeyedHashAlgorithm.Create();

                //Set the key
                hash.Key = _key;

                //Compute the hash
                hashbyte = hash.ComputeHash(fsSource);

                //close the streams
                fsSource.Close();
            }
            catch (Exception)
            {

            }

            return hashbyte;
        }

        /*
         * Generic function 
         */
        public bool CreateHashFile(string _HashFilepath, string _skey)
        {
            //if Key is passed then call keyed hash function
            if (0 != _skey.Length)
            {
                byte[] key = new UnicodeEncoding().GetBytes(_skey);
                return CreateHashFile(_HashFilepath, key);
            }

            //if Key is not passed then call simple hash function
            return CreateHashFile(_HashFilepath);
        }

        /*
         *	Simple Hashing
         * 
         */
        public bool CreateHashFile(string _HashFilepath)
        {
            byte[] key = { };
            return CreateHashFile(_HashFilepath, key);
        }

        /*
         *	Keyed Hashing
         * 
         */
        public bool CreateHashFile(string _HashFilepath, byte[] _key)
        {
            //Ensure that the hash file does not exists, if you don't 
            //want to overwrite
            if (true == File.Exists(_HashFilepath))
                return false;

            try
            {
                //Create the hash file
                FileStream fsHash = File.Create(_HashFilepath);

                byte[] hashbyte;

                //Compute the hash
                if (0 != _key.Length)
                    hashbyte = HashFile(_key);
                else
                    hashbyte = HashFile();

                if (0 == hashbyte.Length)
                    return false;

                //Write the hash to hash file
                fsHash.Write(hashbyte, 0, hashbyte.Length);

                //close the streams
                fsHash.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public class TestFileHash
    {
        [STAThread]
        static void Main(string[] args)
        {
            string file;
            string skey;

            System.Console.Out.Write("Enter the Source File Path :");
            file = System.Console.In.ReadLine();
            if (0 == file.Length)
            {
                System.Console.Out.Write("Bye");
                return;
            }

            System.Console.Out.Write("Enter the secret key (For no secret key just press <Enter>):");
            skey = System.Console.In.ReadLine();

            FileHash fh = new FileHash();
            fh.SourceFile = file;

            byte[] hashbytes = fh.HashFile(skey);
            if (0 == hashbytes.Length)
            {
                System.Console.Out.Write("Failed to hash the file {0}", file);
                return;
            }

            System.Console.Out.Write("Hash/Message Digest :");
            foreach (byte hashbyte in hashbytes)
            {
                Console.Out.Write("{0:x}", hashbyte);
            }

            System.Console.Out.Write("\nEnter the File Path to store hash:");
            file = System.Console.In.ReadLine();
            if (0 == file.Length)
            {
                System.Console.Out.Write("Bye");
                return;
            }

            if (false == fh.CreateHashFile(file, skey))
            {
                System.Console.Out.Write("Failed to create the hash file {0}", file);
                return;
            }
        }
    }
}
