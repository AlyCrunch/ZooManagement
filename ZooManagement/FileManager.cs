using System.IO;

namespace ZooManagement
{
    public interface IFileManager
    {
        string Read(string filePath);
    }

    public class FileManager
    {
        public string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
