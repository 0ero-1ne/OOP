using System;

namespace LabTwelve
{
    class Program
    {
        static void Main()
        {
            DVDiskInfo diskInfo = new DVDiskInfo();
            Console.WriteLine(diskInfo.GetFreeSpaceOfDrive("D"));
            Console.WriteLine(diskInfo.GetDriveFormat("D"));
            Console.WriteLine(diskInfo.GetDrivesInfo());
            Console.WriteLine(DVFileInfo.GetFilePath(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVlogfile.txt"));
            Console.WriteLine(DVFileInfo.GetFileInfo(@"D:\OOP\OOP\LabTwelve\LabTwelve\DVlogfile.txt"));
            Console.WriteLine(DVDirInfo.GetDateOfCreation(@"D:\OOP"));
            Console.WriteLine(DVDirInfo.GetSubdirectoriesAmount(@"D:\OOP"));
            Console.WriteLine(DVDirInfo.GetParentDirectory(@"D:\OOP\OOP"));
            DVFileManager.InspectDrive("D:\\");
            DVFileManager.CopyFiles(@"D:\OOP", ".pdf");
            DVFileManager.CreateArchive();
            DVLog.FindLogsByMonth("12");
            Console.WriteLine(DVLog.GetLogsAmount());
            DVLog.DeleteLogs();
        }
    }
}
