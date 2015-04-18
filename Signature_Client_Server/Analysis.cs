using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}
