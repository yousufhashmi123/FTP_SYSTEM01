using System;
using System.Collections.Generic;
using System.IO;

namespace FtpClientApp;

    public class FileHelper
    {

        public static List<string> GetFileNamesFromFolder(string folderPath)
        {
            List<string> fileNames = new List<string>();

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    fileNames.Add(Path.GetFileName(file));
                }
            }
            else
            {
                Console.WriteLine("The specified folder does not exist.");
            }

            return fileNames;
        }
    }
