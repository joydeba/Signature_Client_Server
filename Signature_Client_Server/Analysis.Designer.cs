namespace Signature_Client_Server
{
    partial class Analysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_sender_sign = new System.Windows.Forms.Label();
            this.label_sender_encrypt = new System.Windows.Forms.Label();
            this.label_ins = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.label_reciver_decrypt = new System.Windows.Forms.Label();
            this.label_reciever_verify = new System.Windows.Forms.Label();
            this.label_reciever_rcv = new System.Windows.Forms.Label();
            this.label_server_status = new System.Windows.Forms.Label();
            this.progressBar_reciever = new System.Windows.Forms.ProgressBar();
            this.button_start = new System.Windows.Forms.Button();
            this.label_sender = new System.Windows.Forms.Label();
            this.label_reciever = new System.Windows.Forms.Label();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_browse);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_file);
            this.splitContainer1.Panel1.Controls.Add(this.label_sender);
            this.splitContainer1.Panel1.Controls.Add(this.label_sender_sign);
            this.splitContainer1.Panel1.Controls.Add(this.label_sender_encrypt);
            this.splitContainer1.Panel1.Controls.Add(this.label_ins);
            this.splitContainer1.Panel1.Controls.Add(this.button_send);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label_reciever);
            this.splitContainer1.Panel2.Controls.Add(this.label_reciver_decrypt);
            this.splitContainer1.Panel2.Controls.Add(this.label_reciever_verify);
            this.splitContainer1.Panel2.Controls.Add(this.label_reciever_rcv);
            this.splitContainer1.Panel2.Controls.Add(this.label_server_status);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar_reciever);
            this.splitContainer1.Panel2.Controls.Add(this.button_start);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(819, 249);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 0;
            // 
            // label_sender_sign
            // 
            this.label_sender_sign.AutoSize = true;
            this.label_sender_sign.Location = new System.Drawing.Point(28, 163);
            this.label_sender_sign.Name = "label_sender_sign";
            this.label_sender_sign.Size = new System.Drawing.Size(84, 13);
            this.label_sender_sign.TabIndex = 3;
            this.label_sender_sign.Text = "Sign Result : ";
            // 
            // label_sender_encrypt
            // 
            this.label_sender_encrypt.AutoSize = true;
            this.label_sender_encrypt.Location = new System.Drawing.Point(28, 126);
            this.label_sender_encrypt.Name = "label_sender_encrypt";
            this.label_sender_encrypt.Size = new System.Drawing.Size(102, 13);
            this.label_sender_encrypt.TabIndex = 2;
            this.label_sender_encrypt.Text = "Encrypt Result : ";
            // 
            // label_ins
            // 
            this.label_ins.AutoSize = true;
            this.label_ins.Location = new System.Drawing.Point(28, 85);
            this.label_ins.Name = "label_ins";
            this.label_ins.Size = new System.Drawing.Size(192, 13);
            this.label_ins.TabIndex = 1;
            this.label_ins.Text = "Select a file to encrypt and sign.";
            // 
            // button_send
            // 
            this.button_send.BackColor = System.Drawing.Color.LavenderBlush;
            this.button_send.Location = new System.Drawing.Point(302, 197);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = false;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label_reciver_decrypt
            // 
            this.label_reciver_decrypt.AutoSize = true;
            this.label_reciver_decrypt.Location = new System.Drawing.Point(44, 172);
            this.label_reciver_decrypt.Name = "label_reciver_decrypt";
            this.label_reciver_decrypt.Size = new System.Drawing.Size(103, 13);
            this.label_reciver_decrypt.TabIndex = 8;
            this.label_reciver_decrypt.Text = "Decrypt Result : ";
            // 
            // label_reciever_verify
            // 
            this.label_reciever_verify.AutoSize = true;
            this.label_reciever_verify.Location = new System.Drawing.Point(44, 145);
            this.label_reciever_verify.Name = "label_reciever_verify";
            this.label_reciever_verify.Size = new System.Drawing.Size(91, 13);
            this.label_reciever_verify.TabIndex = 7;
            this.label_reciever_verify.Text = "Verify Result : ";
            // 
            // label_reciever_rcv
            // 
            this.label_reciever_rcv.AutoSize = true;
            this.label_reciever_rcv.Location = new System.Drawing.Point(44, 116);
            this.label_reciever_rcv.Name = "label_reciever_rcv";
            this.label_reciever_rcv.Size = new System.Drawing.Size(106, 13);
            this.label_reciever_rcv.TabIndex = 6;
            this.label_reciever_rcv.Text = "Recieve Result : ";
            // 
            // label_server_status
            // 
            this.label_server_status.AutoSize = true;
            this.label_server_status.Location = new System.Drawing.Point(232, 17);
            this.label_server_status.Name = "label_server_status";
            this.label_server_status.Size = new System.Drawing.Size(43, 13);
            this.label_server_status.TabIndex = 5;
            this.label_server_status.Text = "Status";
            // 
            // progressBar_reciever
            // 
            this.progressBar_reciever.Location = new System.Drawing.Point(280, 12);
            this.progressBar_reciever.Name = "progressBar_reciever";
            this.progressBar_reciever.Size = new System.Drawing.Size(100, 23);
            this.progressBar_reciever.TabIndex = 1;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.LavenderBlush;
            this.button_start.Location = new System.Drawing.Point(294, 197);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            // 
            // label_sender
            // 
            this.label_sender.AutoSize = true;
            this.label_sender.Location = new System.Drawing.Point(6, 165);
            this.label_sender.Name = "label_sender";
            this.label_sender.Size = new System.Drawing.Size(16, 78);
            this.label_sender.TabIndex = 4;
            this.label_sender.Text = "S\r\nE\r\nN\r\nD\r\nE\r\nR\r\n";
            // 
            // label_reciever
            // 
            this.label_reciever.AutoSize = true;
            this.label_reciever.Location = new System.Drawing.Point(364, 67);
            this.label_reciever.Name = "label_reciever";
            this.label_reciever.Size = new System.Drawing.Size(16, 91);
            this.label_reciever.TabIndex = 9;
            this.label_reciever.Text = "R\r\nE\r\nC\r\nI\r\nV\r\nE\r\nR\r\n";
            this.label_reciever.Click += new System.EventHandler(this.label_reciever_Click);
            // 
            // textBox_file
            // 
            this.textBox_file.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_file.Location = new System.Drawing.Point(31, 45);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.Size = new System.Drawing.Size(265, 20);
            this.textBox_file.TabIndex = 5;
            // 
            // button_browse
            // 
            this.button_browse.BackColor = System.Drawing.Color.LavenderBlush;
            this.button_browse.Location = new System.Drawing.Point(302, 45);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(90, 23);
            this.button_browse.TabIndex = 6;
            this.button_browse.Text = "FileBrowser";
            this.button_browse.UseVisualStyleBackColor = false;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // Analysis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(819, 249);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Analysis";
            this.Text = "Analysis";
            this.TransparencyKey = System.Drawing.Color.White;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_sender_sign;
        private System.Windows.Forms.Label label_sender_encrypt;
        private System.Windows.Forms.Label label_ins;
        private System.Windows.Forms.ProgressBar progressBar_reciever;
        private System.Windows.Forms.Label label_reciver_decrypt;
        private System.Windows.Forms.Label label_reciever_verify;
        private System.Windows.Forms.Label label_reciever_rcv;
        private System.Windows.Forms.Label label_server_status;
        private System.Windows.Forms.Label label_sender;
        private System.Windows.Forms.Label label_reciever;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TextBox textBox_file;
    }
}

