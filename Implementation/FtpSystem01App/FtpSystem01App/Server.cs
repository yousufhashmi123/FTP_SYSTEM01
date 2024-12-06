using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System01.Common;
using System.Runtime.InteropServices;
namespace FtpSystem01App
{
    public partial class Server : Form
    {
        private TcpListener _listener;
        private TcpListener _dataListener;
        private const int CommandPort = 40;
        private const int DataPort = 41;
        private string _currentUser;
        private Boolean isADEnabled = true;

        public object ContextType { get; private set; }

        public Server()
        {
            InitializeComponent();
        }
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Any, CommandPort);
            _listener.Start();

            _dataListener = new TcpListener(IPAddress.Any, DataPort);
            _dataListener.Start();

            Log("FTP Server started...");
            Task.Run(() => AcceptClientsAsync());
        }

        private async Task AcceptClientsAsync()
        {
            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                Log("Client connected...");
                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            using (var networkStream = client.GetStream())
            using (var reader = new StreamReader(networkStream, Encoding.ASCII))
            using (var writer = new StreamWriter(networkStream, Encoding.ASCII) { AutoFlush = true })
            {
                await writer.WriteLineAsync("Server Started");

                while (true)
                {
                    var request = await reader.ReadLineAsync();
                    if (request == null) break;

                    var response = await ProcessRequestAsync(request, writer);
                    await writer.WriteLineAsync(response);

                    if (request.StartsWith(strCommand.Terminate, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                }
            }

            client.Close();
            Log("Client disconnected...");
        }
        private async Task<string> ProcessRequestAsync(string request, StreamWriter writer)
        {
            var parts = request.Split(' ');
            var command = parts[0].ToUpperInvariant();
            var argument = parts.Length > 1 ? parts[1] : null;

            switch (command)
            {
                case strCommand.USER:
                    _currentUser = argument;
                    return "Username OK, need password";
                case strCommand.PASS:
                    return await AuthenticateUserAsync(_currentUser, argument) ? "User logged in" : "Invalid Login";
                case strCommand.Terminate:
                    return "SESSION ENDED";
                case strCommand.PWD:
                    return "is the current directory";
                case strCommand.LIST:
                    return await ListFilesAsync(writer);
                case strCommand.RETRIVE:
                    return await RetrieveFileAsync(argument, writer);
                case strCommand.STORE:
                    return await StoreFileAsync(argument, writer);
                case strCommand.DELETE:
                    return DeleteFile(argument);
                default:
                    return "Invalid Command";
            }
        }

        private async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            return await Task.Run(() =>
            {
                var token = IntPtr.Zero;
                try
                {
                    bool isValid = LogonUser(username, ".", password, 2, 0, ref token);
                    if (isValid)
                    {
                        using (var identity = new WindowsIdentity(token))
                        {
                            return identity.IsAuthenticated;
                        }
                    }
                    return false;
                }
                finally
                {
                    if (token != IntPtr.Zero)
                    {
                        CloseHandle(token);
                    }
                }
            });
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private extern static bool CloseHandle(IntPtr handle);

        private async Task<string> ListFilesAsync(StreamWriter writer)
        {
            var dataClient = await _dataListener.AcceptTcpClientAsync();
            using (var dataStream = dataClient.GetStream())
            using (var dataWriter = new StreamWriter(dataStream, Encoding.ASCII) { AutoFlush = true })
            {
                string executionPath = AppDomain.CurrentDomain.BaseDirectory;
                string directoryPath = Path.Combine(executionPath, "file");

                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    await dataWriter.WriteLineAsync(file);
                }
                await dataWriter.WriteLineAsync("226 Transfer complete");
            }
            dataClient.Close();
            return "Opening data connection for file list";
        }

        private async Task<string> RetrieveFileAsync(string fileName, StreamWriter writer)
        {
            string executionPath = AppDomain.CurrentDomain.BaseDirectory;
            string directoryPath = Path.Combine(executionPath, "file");
            fileName = directoryPath + "\\"+fileName.Replace("%20"," ");
            if (File.Exists(fileName))
            {
                byte[] fileBytes;
                var dataClient = await _dataListener.AcceptTcpClientAsync();
                using (var dataStream = dataClient.GetStream())
                {
                    fileBytes = File.ReadAllBytes(fileName);
                    await dataStream.WriteAsync(fileBytes, 0, fileBytes.Length);
                }
                dataClient.Close();
                return $"Opening data connection for {fileName} ({fileBytes.Length} bytes)\r\n226 Transfer complete";
            }
            else
            {
                return "File not found";
            }
        }

        private async Task<string> StoreFileAsync(string fileName, StreamWriter writer)
        {
            var dataClient = await _dataListener.AcceptTcpClientAsync();
            using (var dataStream = dataClient.GetStream())
            {
                // Get the execution path and create the "file" directory if it doesn't exist
                string executionPath = AppDomain.CurrentDomain.BaseDirectory;
                string directoryPath = Path.Combine(executionPath, "file");
                Directory.CreateDirectory(directoryPath);
                fileName = fileName.Replace("%20", " ");
                string filePath = Path.Combine(directoryPath, fileName);

                // Check if the file already exists and rename if necessary
                if (File.Exists(filePath))
                {
                    string newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{Guid.NewGuid()}{Path.GetExtension(fileName)}";
                    filePath = Path.Combine(directoryPath, newFileName);
                }

                // Write the dataStream to the file
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await dataStream.CopyToAsync(fileStream);
                }
            }
            dataClient.Close();
            return "Opening data connection";
        }

        private string DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                return "File deleted successfully";
            }
            else
            {
                return "File not found";
            }
        }


        private void Log(string message)
        {
            Invoke(new Action(() => richTextBox1.AppendText(message + Environment.NewLine)));
        }

        private void Server_Load(object sender, EventArgs e)
        {
            btnStopServer.Enabled = false;
        }

        private void cbEnabledAD_CheckedChanged(object sender, EventArgs e)
        {
            isADEnabled = cbEnabledAD.Checked;
        }
    }
}
