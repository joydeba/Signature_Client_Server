using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace TextEncryption
{
    public class TextEncryption
    {
        private static CipherMode _mode = CipherMode.CBC; //Cipher Block Chaining Mode
        private static PaddingMode _padding = PaddingMode.PKCS7; //PKCS7 Padding String "03 03 03"
        private RijndaelManaged _rj; //AES 256 Bits Key Block Content-Encyption Cipher

        public TextEncryption(RijndaelManaged rj)
        {
            _rj = rj;
        }

        public TextEncryption(byte[] key)
        {
            _rj = new RijndaelManaged();
            _rj.Mode = _mode;
            _rj.Padding = _padding;
            _rj.Key = key;
        }

        public byte[] Encrypt(string plaintext)
        {
            //Create a memory stream to which CryptoStream will write the cipher text
            MemoryStream ciphertextmem = new MemoryStream();

            //Create a CryptoStream in Write Mode; initialise withe the Rijndael's Encryptor ICryptoTransform
            CryptoStream crystm = new CryptoStream(ciphertextmem, _rj.CreateEncryptor(), CryptoStreamMode.Write);

            //Encode the passed plain text string into Unicode byte stream
            Byte[] plaintextbyte = new UnicodeEncoding().GetBytes(plaintext);

            //Write the plaintext byte stream to CryptoStream
            crystm.Write(plaintextbyte, 0, plaintextbyte.Length);

            //don't forget to close the stream
            crystm.Close();

            //Extract the ciphertext byte stream and close the MemoryStream
            //16 Byte Array - 128 bit block
            Byte[] ciphertextbyte = ciphertextmem.ToArray();
            ciphertextmem.Close();

            return ciphertextbyte;
        }


        public string Decrypt(byte[] ciphertextbyte)
        {

            //Create a memory stream from which CryptoStream will read the cipher text
            MemoryStream ciphertextmem = new MemoryStream(ciphertextbyte);

            //Create a CryptoStream in Read Mode; initialise withe the Rijndael's Decryptor ICryptoTransform
            CryptoStream crystm = new CryptoStream(ciphertextmem, _rj.CreateDecryptor(), CryptoStreamMode.Read);

            //Create a temporary memory stream to which we will copy the plaintext byte array from CryptoStream
            MemoryStream plaintextmem = new MemoryStream();

            do
            {
                //Create a byte array into which we will read the plaintext from CryptoStream
                Byte[] buf = new Byte[100];

                //read the plaintext from CryptoStream
                int actualbytesread = crystm.Read(buf, 0, 100);

                //if we have reached the end of stream quit the loop
                if (0 == actualbytesread)
                    break;

                //copy the plaintext byte array to MemoryStream
                plaintextmem.Write(buf, 0, actualbytesread);

            } while (true);

            //don't forget to close the streams
            crystm.Close();
            ciphertextmem.Close();

            //Extract the plaintext byte stream and close the MemoryStream
            Byte[] plaintextbyte = plaintextmem.ToArray();
            plaintextmem.Close();

            //Encode the plaintext byte into Unicode string
            string plaintext = new UnicodeEncoding().GetString(plaintextbyte);
            return plaintext;
        }

    }

}
