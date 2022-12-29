using System.IO;

namespace LabTwelve
{
    static class DVFileInfo
    {
        public static string GetFilePath(string file)
        {
            return new FileInfo(file).FullName;
        }

        public static string GetFileInfo(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            string info = "";
            info += $"Size: {fileInfo.Length}\nExtension: {fileInfo.Extension}\nName: {fileInfo.Name}\n"; //b
            info += $"Creation date: {fileInfo.CreationTime}\nDate of change: {fileInfo.LastWriteTime}"; //c
            return info;
        }
    }
}
