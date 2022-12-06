using System.IO;
using UnityEngine;

namespace SaveSystem.FileHandler
{
    public class FileHandler : IFileHandler
    {
        private const string folderName = "Data";

        #region Public Methods

        public void DeleteAllFiles()
        {
            DirectoryInfo di = new DirectoryInfo(GetFolderPath());
            di.Delete(true);
        }

        public void DeleteFile(string fileName)
        {
            DeleteFileInternal(fileName);
        }

        public string LoadFile(string fileName)
        {
            return ReadFromFile(fileName);
        }

        public void SaveFile(string fileName, string fileData)
        {
            WriteToFile(fileName, fileData);
        }

        #endregion

        #region Private Methods

        private string GetFolderPath()
        {
            return Application.persistentDataPath + "/" + folderName;
        }

        private string GetFilePath(string fileName)
        {
            Debug.Log($"[Game Data System] File path: {GetFolderPath()}/{fileName}");
            return $"{GetFolderPath()}/{fileName}.json";
            // if (_isDebug) Debug.Log($"[Game Data System] File path: {Application.persistentDataPath + "/" + fileName}");
            // return Application.persistentDataPath + "/" + fileName;
        }

        private void DeleteFileInternal(string fileName)
        {
            string filePath = GetFilePath(fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void WriteToFile(string fileName, string data)
        {
            string folderPath = GetFolderPath();
            string filePath = GetFilePath(fileName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(data);
            }

            // if (_isDebug) Debug.Log("[Game Data System] Write database to file successful");
        }

        private string ReadFromFile(string fileName)
        {
            string filePath = GetFilePath(fileName);

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string data = reader.ReadToEnd();
                    // if (_isDebug) Debug.Log("[Game Data System] Read database from file successful");
                    return data;
                }
            }

            return null;
        }

        #endregion
    }
}