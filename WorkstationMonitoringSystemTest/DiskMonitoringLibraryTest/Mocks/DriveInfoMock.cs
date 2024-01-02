using DiskMonitoringLibrary.Models;

namespace WorkstationMonitoringSystemTest.DiskMonitoringLibraryTest.Mocks
{
    public struct DriveInfoMock : IDriveInfo
    {
        public string VolumeLabel { get; set; }
        public string RootPath { get; set; }
        public string FileSystem { get; set; }
        public ulong TotalSpace { get; set; }
        public ulong FreeSpace { get; set; }

        public static IEnumerable<DriveInfoMock> GetCorrectDriveInfo()
        {
            yield return new DriveInfoMock
            {
                VolumeLabel = "",
                RootPath = "RootPath",
                FileSystem = "FileSystem",
                TotalSpace = 500000,
                FreeSpace = 300000
            };
            yield return new DriveInfoMock
            {
                VolumeLabel = "VolumeLabel",
                RootPath = "RootPath",
                FileSystem = "FileSystem",
                TotalSpace = 500000,
                FreeSpace = 300000
            };
        }

       
    }
}
