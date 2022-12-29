using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LabTwelve
{
    static class DVFileManager
    {
        public static void InspectDrive(string driveName)
        {
            Directory.CreateDirectory(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect");
            File.Create(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVDirInfo.txt").Close();
            var drive = DriveInfo.GetDrives().Single(d => d.Name == driveName);

            using (StreamWriter sw = new StreamWriter(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVDirInfo.txt"))
            {
                sw.WriteLine("Folders:");
                foreach (var folder in drive.RootDirectory.GetDirectories())
                {
                    sw.WriteLine(folder.Name);
                }

                sw.WriteLine("\nFiles:");
                foreach (var file in drive.RootDirectory.GetFiles())
                {
                    sw.WriteLine(file.Name);
                }
            }

            File.Copy(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVDirInfo.txt", @"D:\OOP\OOP\LabTwelve\LabTwelve\DVDirInfo.txt", true);
            File.Delete(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVDirInfo.txt");
        }

        public static void CopyFiles(string path, string ext)
        {
            Directory.CreateDirectory(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVFiles");
            DirectoryInfo startDirectory = new DirectoryInfo(path);
            DirectoryInfo endDirectory = new DirectoryInfo(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVFiles");

            foreach (var file in startDirectory.GetFiles())
            {
                if (file.Extension == ext.ToLower())
                    file.CopyTo(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVFiles\" + file.Name + ext, true);
            }

            if (!endDirectory.Exists)
                Directory.Move(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVFiles", @"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVFiles");
            else
                Directory.Delete(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVFiles", true);
        }

        public static void CreateArchive()
        {
            string files = @"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVFiles";
            var archiveFolder = new DirectoryInfo(@"D:\OOP\OOP\LabTwelve\LabTwelve\Archive");
            if (archiveFolder.Exists)
                Directory.Delete(@"D:\OOP\OOP\LabTwelve\LabTwelve\Archive", true);
            ZipFile.CreateFromDirectory(files, @"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVFiles.zip");
            ZipFile.ExtractToDirectory(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVFiles.zip", @"D:\OOP\OOP\LabTwelve\LabTwelve\Archive");
            File.Delete(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVInspect\DVFiles.zip");
        }
    }
}
