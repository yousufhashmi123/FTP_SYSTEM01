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
        button1 = new Button();
        btnUpload = new Button();
        btnDelete = new Button();
        btnDownload = new Button();
        tabControl1 = new TabControl();
        tabUpload = new TabPage();
        txtFilePath = new TextBox();
        tabDownload = new TabPage();
        btnRefresh = new Button();
        lblUploadedFiles = new Label();
        dataGridView1 = new DataGridView();
        label5 = new Label();
        txtIP = new TextBox();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        tabControl1.SuspendLayout();
        tabUpload.SuspendLayout();
        tabDownload.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(txtIP);
        groupBox1.Controls.Add(label5);
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
        groupBox1.Size = new Size(487, 258);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Connection Settings";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(126, 130);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(338, 27);
        txtPassword.TabIndex = 9;
        txtPassword.Text = "admin1234";
        txtPassword.UseSystemPasswordChar = true;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(24, 133);
        label4.Name = "label4";
        label4.Size = new Size(70, 20);
        label4.TabIndex = 8;
        label4.Text = "Password";
        // 
        // txtUser
        // 
        txtUser.Location = new Point(126, 99);
        txtUser.Name = "txtUser";
        txtUser.Size = new Size(338, 27);
        txtUser.TabIndex = 7;
        txtUser.Text = "admin";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(21, 104);
        label3.Name = "label3";
        label3.Size = new Size(82, 20);
        label3.TabIndex = 6;
        label3.Text = "User Name";
        // 
        // btnDisconnect
        // 
        btnDisconnect.Enabled = false;
        btnDisconnect.Location = new Point(256, 206);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(208, 29);
        btnDisconnect.TabIndex = 5;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // btnConnect
        // 
        btnConnect.Location = new Point(20, 205);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(208, 29);
        btnConnect.TabIndex = 4;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // txtDataPort
        // 
        txtDataPort.Location = new Point(126, 67);
        txtDataPort.Name = "txtDataPort";
        txtDataPort.Size = new Size(338, 27);
        txtDataPort.TabIndex = 3;
        txtDataPort.Text = "41";
        // 
        // txtComPort
        // 
        txtComPort.Location = new Point(126, 33);
        txtComPort.Name = "txtComPort";
        txtComPort.Size = new Size(338, 27);
        txtComPort.TabIndex = 2;
        txtComPort.Text = "40";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(20, 70);
        label2.Name = "label2";
        label2.Size = new Size(71, 20);
        label2.TabIndex = 1;
        label2.Text = "Data Port";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(20, 34);
        label1.Name = "label1";
        label1.Size = new Size(70, 20);
        label1.TabIndex = 0;
        label1.Text = "Com Port";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(txtLogs);
        groupBox2.Location = new Point(27, 276);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(487, 428);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Logs";
        // 
        // txtLogs
        // 
        txtLogs.Location = new Point(6, 26);
        txtLogs.Name = "txtLogs";
        txtLogs.Size = new Size(475, 396);
        txtLogs.TabIndex = 0;
        txtLogs.Text = "";
        txtLogs.TextChanged += txtLogs_TextChanged;
        // 
        // button1
        // 
        button1.Location = new Point(306, 27);
        button1.Name = "button1";
        button1.Size = new Size(147, 29);
        button1.TabIndex = 1;
        button1.Text = "select File";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // btnUpload
        // 
        btnUpload.Location = new Point(17, 85);
        btnUpload.Name = "btnUpload";
        btnUpload.Size = new Size(202, 29);
        btnUpload.TabIndex = 0;
        btnUpload.Text = "Upload";
        btnUpload.UseVisualStyleBackColor = true;
        btnUpload.Click += btnUpload_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(287, 295);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(174, 29);
        btnDelete.TabIndex = 1;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnDownload
        // 
        btnDownload.Location = new Point(20, 295);
        btnDownload.Name = "btnDownload";
        btnDownload.Size = new Size(174, 29);
        btnDownload.TabIndex = 0;
        btnDownload.Text = "Download";
        btnDownload.UseVisualStyleBackColor = true;
        btnDownload.Click += btnDownload_Click;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabUpload);
        tabControl1.Controls.Add(tabDownload);
        tabControl1.Enabled = false;
        tabControl1.Location = new Point(538, 22);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(475, 682);
        tabControl1.TabIndex = 4;
        // 
        // tabUpload
        // 
        tabUpload.Controls.Add(txtFilePath);
        tabUpload.Controls.Add(btnUpload);
        tabUpload.Controls.Add(button1);
        tabUpload.Location = new Point(4, 29);
        tabUpload.Name = "tabUpload";
        tabUpload.Padding = new Padding(3);
        tabUpload.Size = new Size(467, 649);
        tabUpload.TabIndex = 0;
        tabUpload.Text = "Upload";
        tabUpload.UseVisualStyleBackColor = true;
        // 
        // txtFilePath
        // 
        txtFilePath.Location = new Point(17, 27);
        txtFilePath.Name = "txtFilePath";
        txtFilePath.ReadOnly = true;
        txtFilePath.Size = new Size(283, 27);
        txtFilePath.TabIndex = 3;
        // 
        // tabDownload
        // 
        tabDownload.Controls.Add(btnRefresh);
        tabDownload.Controls.Add(lblUploadedFiles);
        tabDownload.Controls.Add(btnDelete);
        tabDownload.Controls.Add(dataGridView1);
        tabDownload.Controls.Add(btnDownload);
        tabDownload.Location = new Point(4, 29);
        tabDownload.Name = "tabDownload";
        tabDownload.Padding = new Padding(3);
        tabDownload.Size = new Size(467, 649);
        tabDownload.TabIndex = 1;
        tabDownload.Text = "Donwload";
        tabDownload.UseVisualStyleBackColor = true;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(287, 26);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(174, 29);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "Refresh";
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // lblUploadedFiles
        // 
        lblUploadedFiles.AutoSize = true;
        lblUploadedFiles.Location = new Point(20, 31);
        lblUploadedFiles.Name = "lblUploadedFiles";
        lblUploadedFiles.Size = new Size(174, 20);
        lblUploadedFiles.TabIndex = 1;
        lblUploadedFiles.Text = "Uploaded Files on Server";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(20, 69);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(441, 195);
        dataGridView1.TabIndex = 0;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(24, 168);
        label5.Name = "label5";
        label5.Size = new Size(62, 20);
        label5.TabIndex = 10;
        label5.Text = "Address";
        // 
        // txtIP
        // 
        txtIP.Location = new Point(126, 161);
        txtIP.Name = "txtIP";
        txtIP.Size = new Size(338, 27);
        txtIP.TabIndex = 11;
        txtIP.Text = "127.0.0.1";
        // 
        // Client
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1027, 713);
        Controls.Add(tabControl1);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "Client";
        Text = "FTP Client";
        Load += Client_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        tabControl1.ResumeLayout(false);
        tabUpload.ResumeLayout(false);
        tabUpload.PerformLayout();
        tabDownload.ResumeLayout(false);
        tabDownload.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
    private Button btnDelete;
    private Button btnDownload;
    private Button btnUpload;
    private Button button1;
    private TabControl tabControl1;
    private TabPage tabUpload;
    private TabPage tabDownload;
    private DataGridView dataGridView1;
    private Label lblUploadedFiles;
    private Button btnRefresh;
    private TextBox txtFilePath;
    private TextBox txtIP;
    private Label label5;
}
