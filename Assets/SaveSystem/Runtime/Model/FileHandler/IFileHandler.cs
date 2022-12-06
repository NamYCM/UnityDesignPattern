namespace SaveSystem.FileHandler
{
    public interface IFileHandler
    {
        void SaveFile(string fileName, string fileData);
        string LoadFile(string fileName);
        void DeleteFile(string fileName);
        void DeleteAllFiles();
    }
}