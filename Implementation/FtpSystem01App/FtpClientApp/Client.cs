using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System01.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FtpClientApp;


public partial class Client : Form
{
    private TcpClient _commandClient;
    private TcpClient _dataClient;
    private NetworkStream _commandStream;
    private StreamReader _commandReader;
    private StreamWriter _commandWriter;
    private List<string> _uploadedFileNames = new List<string>();

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
                    _uploadedFileNames.RemoveAll(x => 1 == 1);
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (!line.Contains("226 Transfer complete"))
                        {
                            _uploadedFileNames.Add(line);
                            
                        }
                        
                    }

                }
            }
            else if (command == strCommand.LISTFILES)
            {
                using (var reader = new StreamReader(dataStream, Encoding.ASCII))
                {
                    // Read the JSON string from the data stream
                    string json = await reader.ReadToEndAsync();

                    // Deserialize the JSON string into a list of file names
                    List<string> fileNames = JsonSerializer.Deserialize<List<string>>(json);

                    // Process the list of file names (e.g., display them in a DataGridView)
                    foreach (var fileName in fileNames)
                    {
                        Log(fileName);
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
                    //await fileStream.CopyToAsync(dataStream);
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    Log2("Sending Data");
                    int len = 0;
                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        
                        await dataStream.WriteAsync(buffer, 0, bytesRead);
                        len++;
                        if (len%600==0)
                        {
                            Log2("*");
                        }
                    }
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

    private void Log2(string message)
    {
        Invoke(new Action(() => txtLogs.AppendText(message)));
    }

    private async void btnConnect_Click(object sender, EventArgs e)
    {
        try
        {
            _commandClient = new TcpClient();
            await _commandClient.ConnectAsync(txtIP.Text, int.Parse(txtComPort.Text));
            _commandStream = _commandClient.GetStream();
            _commandReader = new StreamReader(_commandStream, Encoding.ASCII);
            _commandWriter = new StreamWriter(_commandStream, Encoding.ASCII) { AutoFlush = true };

            toggleButtonEnablement();


            Log(await _commandReader.ReadLineAsync());

            await updateGrid();

        }
        catch(Exception ex)
        {
            Log($"Error {ex.Message}");
        }
        

    }

    private async void btnDisconnect_Click(object sender, EventArgs e)
    {
        try
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
            toggleButtonEnablement();

        }
        catch (Exception ex)
        {
            Log($"Error {ex.Message}");
        }
        


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
        try
        {
            
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please select a file to upload");
                return;
            }
            btnUpload.Enabled = false;


            string fileName = txtFilePath.Text;
            string command = $"{strCommand.STORE} {Path.GetFileName(fileName).Replace(" ", "%20")}";
            await _commandWriter.WriteLineAsync(command);
            System.Threading.Thread.Sleep(1000);

            await HandleDataConnectionAsync(strCommand.STORE, fileName);

            txtFilePath.Text = "";
            MessageBox.Show("File Uploaded");
            btnUpload.Enabled = true;
            await updateGrid();
        }
        catch(Exception ex)
        {
            btnUpload.Enabled = true;
            Log($"Error {ex.Message}");
        }
       

    }

    private async void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            btnDownload.Enabled = false;
            string filePath = "";
            string fileName = _uploadedFileNames[dataGridView1.SelectedRows[0].Index];
            //string filePath = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = folderDialog.SelectedPath;
                }
            }


            fileName = Path.GetFileName(fileName);
            string command = $"{strCommand.RETRIVE} {fileName.Replace(" ", "%20")}";
            await _commandWriter.WriteLineAsync(command);
            System.Threading.Thread.Sleep(1000);

            await HandleDataConnectionAsync(strCommand.RETRIVE, filePath + "\\" + fileName);
            MessageBox.Show("File Downloaded");
            btnDownload.Enabled = true;
        }
        catch(Exception ex)
        {
            btnDownload.Enabled = false;
            Log($"Error {ex.Message}");
        }
        

    }

    private async void Client_Load(object sender, EventArgs e)
    {
        
    }
    private void LoadFileNamesIntoDataGridView(string folderPath)
    {
        //dataGridView1.DataSource = fileNames.Select(fileName => new { FileName = fileName }).ToList();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await updateGrid();
    }

    private async Task updateGrid()
    {
        try
        {
            string command = $"{strCommand.LIST}";
            await _commandWriter.WriteLineAsync(command);
            System.Threading.Thread.Sleep(1000);
            await HandleDataConnectionAsync(strCommand.LIST);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _uploadedFileNames.Select(x => new { Files = Path.GetFileName(x) }).ToList();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Refresh();
        }
        catch(Exception ex)
        {
            Log($"Error {ex.Message}");
        }
        
    }

    private void toggleButtonEnablement()
    {
        btnConnect.Enabled = !btnConnect.Enabled;
        btnDisconnect.Enabled = !btnDisconnect.Enabled;
        tabControl1.Enabled = !tabControl1.Enabled;
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = _uploadedFileNames[dataGridView1.SelectedRows[0].Index];
            string fileName = "" + Path.GetFileName(filePath);
            string command = $"{strCommand.DELETE} {fileName.Replace(" ", "%20")}";
            await _commandWriter.WriteLineAsync(command);
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show("File Deleted");
            await updateGrid();
        }
        catch(Exception ex)
        {
            Log($"Error {ex.Message}");
        }
        
    }
}
