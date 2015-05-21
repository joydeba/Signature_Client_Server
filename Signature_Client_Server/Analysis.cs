using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Signature_Client_Server
{
    public partial class Analysis : Form
    {
        byte[] global_hashvalue;
        byte[] global_sign;
        public Analysis()
        {
            InitializeComponent();
        }

        private void label_reciever_Click(object sender, EventArgs e)
        {

        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox_file.Text = fdlg.FileName;
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {

            
            string file = textBox_file.Text;

            if (0 == file.Length)
            {
                label_ins.ForeColor = System.Drawing.Color.Red;

                HashAFile haf = new HashAFile(file);
                return;
            }
            HashAFile hash = new HashAFile(file);
            byte[] hashbytes = hash.HashFile();

            if (0 == hashbytes.Length)
            {
                label_ins.Text = "Failed to hash the file" + file;
                return;
            }


            string temp = "";
            foreach (byte hashbyte in hashbytes)
            {

                temp = temp + " " + hashbyte;
            }
            richTextBox_hash_value.Text = "Hash/Message Digest :" + temp;
            global_hashvalue = hashbytes;

            if (false == hash.CreateHashFile(file+"1"))
            {
                label_ins.Text = "Failed to create the hash file ";
                return;
            }
            

        }

        private void button_send_sign_Click(object sender, EventArgs e)
        {
            Signature sign = new Signature("SHA1");
            byte[] signature = sign.Sign(global_hashvalue);

            string temp = "";
            foreach (byte hashbyte in signature)
            {

                temp = temp + " " + hashbyte;
            }
            richTextBox_hash_value.Text = "Signature/Message Digest :" + temp;
            global_sign = signature;

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            string file = textBox_file.Text;
            Signature verify = new Signature("SHA1");
            byte[] signature = global_sign;
            bool valid_or_not = verify.Validate(file, signature);

            if (valid_or_not)
            {
                label_reciever_rcv.Text = label_reciever_rcv.Text + " OK";
                label_reciever_verify.Text = label_reciever_verify.Text + " OK";
            }   
                

        }

        private void button_sender_key_gen_Click(object sender, EventArgs e)
        {
            string xmlRSAKeyPair = "<RSAKeyValue><Modulus>22BoUo2P28KglLh8G5gyOPXHFYDjF3i+KTNoE3wiSj+egBzM44Y+Ap4eeNQaBPrSp7PmGrLQp6sjBF1817llvCqTnk18V+EdMsJ5hUT5SzEFwCcPqSDH9Ns1wM/hP541RCTe+E53mAnovVKPoS4en+SnCnp2Lxnne01B4an8PM0=</Modulus><Exponent>AQAB</Exponent><P>8jIknnZvylSfuJE/XIiWVAPmD1z6T7cu53rBGVyXmIVfmqqC20f6IISERd1cvhrOLc+5IIUYt5uPXW1LHkYjTw==</P><Q>5+FPfr2qHrdZprpL7qaJUTw3N5JnBYzG+lNC/ZEk7qVWddVCQjaKfE8D7M8sYeT5o+WnoW+CHh83daBRrx3HIw==</Q><DP>yPBLK2Ft7Dr7bOCs5fO4bSny5Ioqbpq3gnt427bTW0pEgIi5Gn8ECZiIOYKnoF2S87UkjdN/J04bytKTgSGFxw==</DP><DQ>0XK9+JBfIuGgtC4guk9pR5xpj+PI9MVlUeV1ZE7/miR0RXk9IUvcqU5CEFxODZrjN30QfoyXbpfp43DNd60hGw==</DQ><InverseQ>eZ0h/wsZEhwUcprax89t3VEZfuACP2R8IGmvlOPQ89clxAR/twbF4aSPwoEiFJ8v0fgoceRQ8BP7S3CowhcWFw==</InverseQ><D>AKtiph3Yeos1gj6t4kesn4/gc6hZCRFNQ0Ls5mJSmHdpPGraFTerqMZiwWukSK+bRPe/lAVHrbtP+Atw/heKv+7O9VIAZnADXXF4CnNAsrFSgRS+BHoShQytzF2kIJpJZfWZ9MYJfI2wquDWCJTCc1ZbdnEhtBohKMvWrP8fV+E=</D></RSAKeyValue>";
            Sender sender_s = new Sender();
            CspParameters csp = new CspParameters();
            csp.ProviderType = 1;
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);
            rsa.FromXmlString(xmlRSAKeyPair);
            string p_key = sender_s.SetReceiverPublicKey(rsa.ExportParameters(false));
            richTextBox_hash_value.Text = "Imported RSA Public Key: \n" + p_key;
            
        }






        private void button_reciever_key_gen_Click(object sender, EventArgs e)
        {
            CspParameters csp = new CspParameters();
            csp.ProviderType = 1;
            csp.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);
            Receiver receiver_r = new Receiver();
           // receiver_r.SetReceiverKeyPair(rsa.ExportParameters(true));

        }
    }
}
