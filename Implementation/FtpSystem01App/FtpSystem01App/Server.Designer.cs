



namespace FtpSystem01App
{
    partial class Server
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            cbEnabledAD = new CheckBox();
            btnStopServer = new Button();
            txtDataPort = new TextBox();
            txtCommandPort = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnStartServer = new Button();
            groupBox2 = new GroupBox();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbEnabledAD);
            groupBox1.Controls.Add(btnStopServer);
            groupBox1.Controls.Add(txtDataPort);
            groupBox1.Controls.Add(txtCommandPort);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnStartServer);
            groupBox1.Location = new Point(41, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(454, 228);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "FTP Server";
            // 
            // cbEnabledAD
            // 
            cbEnabledAD.AutoSize = true;
            cbEnabledAD.Location = new Point(23, 119);
            cbEnabledAD.Name = "cbEnabledAD";
            cbEnabledAD.Size = new Size(110, 24);
            cbEnabledAD.TabIndex = 7;
            cbEnabledAD.Text = "AD Enabled";
            cbEnabledAD.UseVisualStyleBackColor = true;
            cbEnabledAD.CheckedChanged += cbEnabledAD_CheckedChanged;
            // 
            // btnStopServer
            // 
            btnStopServer.Enabled = false;
            btnStopServer.Location = new Point(233, 168);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(207, 29);
            btnStopServer.TabIndex = 6;
            btnStopServer.Text = "Stop Server";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // txtDataPort
            // 
            txtDataPort.Location = new Point(179, 75);
            txtDataPort.Name = "txtDataPort";
            txtDataPort.Size = new Size(261, 27);
            txtDataPort.TabIndex = 5;
            txtDataPort.Text = "41";
            // 
            // txtCommandPort
            // 
            txtCommandPort.Location = new Point(179, 36);
            txtCommandPort.Name = "txtCommandPort";
            txtCommandPort.Size = new Size(261, 27);
            txtCommandPort.TabIndex = 4;
            txtCommandPort.Text = "40";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 75);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 3;
            label2.Text = "Data Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 39);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 2;
            label1.Text = "Command PORT";
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(26, 169);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(181, 29);
            btnStartServer.TabIndex = 1;
            btnStartServer.Text = "Start Server";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Location = new Point(41, 283);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(454, 155);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Logs";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(6, 26);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(434, 120);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Server";
            Text = "FTP Server";
            Load += Server_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }









        #endregion

        private GroupBox groupBox1;
        private Button btnStartServer;
        private RadioButton rbUseAD;
        private TextBox txtDataPort;
        private TextBox txtCommandPort;
        private Label label2;
        private Label label1;
        private Button btnStopServer;
        private GroupBox groupBox2;
        private RichTextBox richTextBox1;
        private CheckBox cbEnabledAD;
    }
}
