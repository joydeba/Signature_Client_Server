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


        }
    }
}
