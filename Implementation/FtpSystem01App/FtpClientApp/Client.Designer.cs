namespace FtpClientApp;

partial class Client
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
        txtPassword = new TextBox();
        label4 = new Label();
        txtUser = new TextBox();
        label3 = new Label();
        btnDisconnect = new Button();
        btnConnect = new Button();
        txtDataPort = new TextBox();
        txtComPort = new TextBox();
        label2 = new Label();
        label1 = new Label();
        groupBox2 = new GroupBox();
        txtLogs = new RichTextBox();
        groupBox3 = new GroupBox();
        txtFilePath = new TextBox();
        button1 = new Button();
        btnUpload = new Button();
        groupBox4 = new GroupBox();
        label5 = new Label();
        lstFiles = new ComboBox();
        btnDelete = new Button();
        btnDownload = new Button();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox4.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(txtPassword);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(txtUser);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(btnDisconnect);
        groupBox1.Controls.Add(btnConnect);
        groupBox1.Controls.Add(txtDataPort);
        groupBox1.Controls.Add(txtComPort);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Location = new Point(27, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(487, 205);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Client";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(125, 119);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(338, 27);
        txtPassword.TabIndex = 9;
        txtPassword.Text = "admin1234";
        txtPassword.UseSystemPasswordChar = true;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(23, 122);
        label4.Name = "label4";
        label4.Size = new Size(70, 20);
        label4.TabIndex = 8;
        label4.Text = "Password";
        // 
        // txtUser
        // 
        txtUser.Location = new Point(125, 88);
        txtUser.Name = "txtUser";
        txtUser.Size = new Size(338, 27);
        txtUser.TabIndex = 7;
        txtUser.Text = "admin";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(20, 93);
        label3.Name = "label3";
        label3.Size = new Size(82, 20);
        label3.TabIndex = 6;
        label3.Text = "User Name";
        // 
        // btnDisconnect
        // 
        btnDisconnect.Location = new Point(255, 157);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(208, 29);
        btnDisconnect.TabIndex = 5;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // btnConnect
        // 
        btnConnect.Location = new Point(19, 158);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(208, 29);
        btnConnect.TabIndex = 4;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // txtDataPort
        // 
        txtDataPort.Location = new Point(125, 56);
        txtDataPort.Name = "txtDataPort";
        txtDataPort.Size = new Size(338, 27);
        txtDataPort.TabIndex = 3;
        txtDataPort.Text = "41";
        // 
        // txtComPort
        // 
        txtComPort.Location = new Point(125, 22);
        txtComPort.Name = "txtComPort";
        txtComPort.Size = new Size(338, 27);
        txtComPort.TabIndex = 2;
        txtComPort.Text = "40";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(19, 59);
        label2.Name = "label2";
        label2.Size = new Size(71, 20);
        label2.TabIndex = 1;
        label2.Text = "Data Port";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(19, 23);
        label1.Name = "label1";
        label1.Size = new Size(70, 20);
        label1.TabIndex = 0;
        label1.Text = "Com Port";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(txtLogs);
        groupBox2.Location = new Point(27, 516);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(487, 188);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Logs";
        // 
        // txtLogs
        // 
        txtLogs.Location = new Point(6, 25);
        txtLogs.Name = "txtLogs";
        txtLogs.Size = new Size(475, 146);
        txtLogs.TabIndex = 0;
        txtLogs.Text = "";
        txtLogs.TextChanged += txtLogs_TextChanged;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(txtFilePath);
        groupBox3.Controls.Add(button1);
        groupBox3.Controls.Add(btnUpload);
        groupBox3.Location = new Point(27, 223);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(487, 112);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "File Upload";
        // 
        // txtFilePath
        // 
        txtFilePath.Location = new Point(19, 26);
        txtFilePath.Name = "txtFilePath";
        txtFilePath.ReadOnly = true;
        txtFilePath.Size = new Size(291, 27);
        txtFilePath.TabIndex = 10;
        // 
        // button1
        // 
        button1.Location = new Point(317, 26);
        button1.Name = "button1";
        button1.Size = new Size(147, 29);
        button1.TabIndex = 1;
        button1.Text = "select File";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // btnUpload
        // 
        btnUpload.Location = new Point(20, 72);
        btnUpload.Name = "btnUpload";
        btnUpload.Size = new Size(202, 29);
        btnUpload.TabIndex = 0;
        btnUpload.Text = "Upload";
        btnUpload.UseVisualStyleBackColor = true;
        btnUpload.Click += btnUpload_Click;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(label5);
        groupBox4.Controls.Add(lstFiles);
        groupBox4.Controls.Add(btnDelete);
        groupBox4.Controls.Add(btnDownload);
        groupBox4.Location = new Point(27, 341);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(487, 169);
        groupBox4.TabIndex = 3;
        groupBox4.TabStop = false;
        groupBox4.Text = "File Upload";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(23, 78);
        label5.Name = "label5";
        label5.Size = new Size(0, 20);
        label5.TabIndex = 3;
        // 
        // lstFiles
        // 
        lstFiles.FormattingEnabled = true;
        lstFiles.Location = new Point(22, 37);
        lstFiles.Name = "lstFiles";
        lstFiles.Size = new Size(440, 28);
        lstFiles.TabIndex = 2;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(233, 124);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(230, 29);
        btnDelete.TabIndex = 1;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        // 
        // btnDownload
        // 
        btnDownload.Location = new Point(23, 124);
        btnDownload.Name = "btnDownload";
        btnDownload.Size = new Size(204, 29);
        btnDownload.TabIndex = 0;
        btnDownload.Text = "Download";
        btnDownload.UseVisualStyleBackColor = true;
        btnDownload.Click += btnDownload_Click;
        // 
        // Client
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(538, 716);
        Controls.Add(groupBox4);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "Client";
        Text = "FTP Client";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private TextBox txtDataPort;
    private TextBox txtComPort;
    private Label label2;
    private Label label1;
    private GroupBox groupBox2;
    private RichTextBox txtLogs;
    private Button btnDisconnect;
    private Button btnConnect;
    private TextBox txtPassword;
    private Label label4;
    private TextBox txtUser;
    private Label label3;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private Label label5;
    private ComboBox lstFiles;
    private Button btnDelete;
    private Button btnDownload;
    private Button btnUpload;
    private Button button1;
    private TextBox txtFilePath;
}
