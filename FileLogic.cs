using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class FileLogic
    {
        private readonly string filePath;
        public FileLogic(string fileName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string subfolder = Path.Combine(baseDir, "Data");
            if (!Directory.Exists(subfolder))
            {
                Directory.CreateDirectory(subfolder);
            }
            filePath = Path.Combine(subfolder, fileName);
        }

        public string LoadData()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                CreateFile();
                return "";
            }
        }

        public void SaveData(string data)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(data);
            }
        }

        private void CreateFile()
        {
            using (FileStream fs = File.Create(filePath))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write("");
                }
            }
        }
    }
}
