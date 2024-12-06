using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System01.Common;

namespace FtpClientApp;


public partial class Client : Form
{
    private TcpClient _commandClient;
    private TcpClient _dataClient;
    private NetworkStream _commandStream;
    private StreamReader _commandReader;
    private StreamWriter _commandWriter;

    public Client()
    {
        InitializeComponent();
    }

    private void txtLogs_TextChanged(object sender, EventArgs e)
    {

    }


    private async Task HandleDataConnectionAsync(string command, string data = "")
    {
        _dataClient = new TcpClient();
        await _dataClient.ConnectAsync("127.0.0.1", int.Parse(txtDataPort.Text));
        using (var dataStream = _dataClient.GetStream())
        {
            if (command == strCommand.LIST)
            {
                using (var reader = new StreamReader(dataStream, Encoding.ASCII))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        Log(line);
                    }
                }
            }
            else if (command == strCommand.RETRIVE)
            {
                
                var filePath = data;
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await dataStream.CopyToAsync(fileStream);
                }
                Log($"File Saved on Path {filePath} successfully.");
            }
            else if (command == strCommand.STORE)
            {
                var fileName = data;
                var filePath = Path.Combine("ClientFiles", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    await fileStream.CopyToAsync(dataStream);
                }
                Log($"File {fileName} uploaded successfully.");
            }
        }
        _dataClient.Close();
    }

    private void Log(string message)
    {
        Invoke(new Action(() => txtLogs.AppendText(message + Environment.NewLine)));
    }

    private async void btnConnect_Click(object sender, EventArgs e)
    {
        _commandClient = new TcpClient();
        await _commandClient.ConnectAsync("127.0.0.1", int.Parse(txtComPort.Text));
        _commandStream = _commandClient.GetStream();
        _commandReader = new StreamReader(_commandStream, Encoding.ASCII);
        _commandWriter = new StreamWriter(_commandStream, Encoding.ASCII) { AutoFlush = true };

        Log(await _commandReader.ReadLineAsync());

    }

    private async void btnDisconnect_Click(object sender, EventArgs e)
    {
        var username = txtUser.Text;
        var password = txtPassword.Text;

        await _commandWriter.WriteLineAsync($"{strCommand.USER} {username}");
        Log(await _commandReader.ReadLineAsync());

        await _commandWriter.WriteLineAsync($"{strCommand.PASS} {password}");
        Log(await _commandReader.ReadLineAsync());

        string command = $"{strCommand.LIST}";
        await _commandWriter.WriteLineAsync(command);
        System.Threading.Thread.Sleep(1000);
        await HandleDataConnectionAsync(strCommand.LIST);



    }

    private void button1_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;

            }
        }
    }

    

    private async void btnUpload_Click(object sender, EventArgs e)
    {
        string fileName = txtFilePath.Text;
        string command = $"{strCommand.STORE} {Path.GetFileName(fileName).Replace(" ", "%20")}";
        await _commandWriter.WriteLineAsync(command);
        System.Threading.Thread.Sleep(1000);

        await HandleDataConnectionAsync(strCommand.STORE, fileName);

    }

    private async void btnDownload_Click(object sender, EventArgs e)
    {
        string filePath = "";
        using (var folderDialog = new FolderBrowserDialog())
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = folderDialog.SelectedPath;
            }
        }
        string fileName = "BRD - Documents Attestation Validation Feature - Version 1.0.docx";
        string command = $"{strCommand.RETRIVE} {fileName.Replace(" ", "%20")}";
        await _commandWriter.WriteLineAsync(command);
        System.Threading.Thread.Sleep(1000);

        await HandleDataConnectionAsync(strCommand.RETRIVE, filePath+ "\\"+fileName);

    }
}
