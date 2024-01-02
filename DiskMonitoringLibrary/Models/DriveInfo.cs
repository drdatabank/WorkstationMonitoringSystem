using System.Runtime.InteropServices;

namespace DiskMonitoringLibrary.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct DriveInfo : IDriveInfo
    {
        public string VolumeLabel { get; set; }
        public string RootPath { get; set; }
        public string FileSystem { get; set; }
        public ulong TotalSpace { get; set; }
        public ulong FreeSpace { get; set; }
    }
}
