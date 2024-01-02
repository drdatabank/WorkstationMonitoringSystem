namespace DiskMonitoringLibrary.Models
{
    public interface IDriveInfo
    {
        string VolumeLabel { get; set; }
        string RootPath { get; set; }
        string FileSystem { get; set; }
        ulong TotalSpace { get; set; }
        ulong FreeSpace { get; set; }
    }
}
