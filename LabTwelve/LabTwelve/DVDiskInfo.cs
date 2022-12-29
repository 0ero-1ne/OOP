using System.IO;

namespace LabTwelve
{
    class DVDiskInfo
    {
        public string GetFreeSpaceOfDrive(string driveName)
        {
            return new DriveInfo(driveName).AvailableFreeSpace.ToString();
        }

        public string GetDriveFormat(string driveName)
        {
            return new DriveInfo(driveName).DriveFormat;
        }

        public string GetDrivesInfo()
        {
            string drives = "";
            var allDrives = DriveInfo.GetDrives();

            foreach (var drive in allDrives)
            {
                if (drive.IsReady)
                {
                    string info = $"Drive name: {drive.Name} - Drive size: {drive.TotalSize} - Drive avaliable value: {drive.AvailableFreeSpace} - Label: {drive.VolumeLabel}";
                    drives += info + "\n";
                }
            }

            return drives;
        }
    }
}
