using System.IO;

namespace LabTwelve
{
    static class DVDirInfo
    {
        public static int GetFilesAmount(string dirName)
        {
            return new DirectoryInfo(dirName).GetFiles().Length;
        }

        public static string GetDateOfCreation(string dirName)
        {
            return new DirectoryInfo(dirName).CreationTime.ToString();
        }

        public static int GetSubdirectoriesAmount(string dirName)
        {
            return new DirectoryInfo(dirName).GetDirectories().Length;
        }

        public static string GetParentDirectory(string dirName)
        {
            return new DirectoryInfo(dirName).Parent.ToString();
        }
    }
}
