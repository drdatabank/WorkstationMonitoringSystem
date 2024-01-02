using DiskMonitoringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static DiskMonitoringLibrary.Kernel;

[assembly: InternalsVisibleTo("WorkstationMonitoringSystemTest")]
namespace DiskMonitoringLibrary
{
    internal static class DiskMonitoring
    {
        internal static List<string> GetVolumes()
        {
            var results = new List<string>();
            // Buffer for the volume name
            StringBuilder volumeName = new StringBuilder(256);

            // Handle to the first volume
            IntPtr hFindVolume = FindFirstVolume(volumeName, (uint)volumeName.Capacity);

            if (hFindVolume == IntPtr.Zero)
            {
                Console.WriteLine("FindFirstVolume failed. Error code: " + Marshal.GetLastWin32Error());
                return results;
            }

            do
            {
                //Console.WriteLine("Volume Name: " + volumeName);
                results.Add(volumeName.ToString());
                // Move to the next volume
            } while (FindNextVolume(hFindVolume, volumeName, (uint)volumeName.Capacity));

            // Cleaning up - closing the handle
            FindVolumeClose(hFindVolume);
            return results;
        }

        [Obsolete("This method is under reconstruction. Don't use it.", false)]
        internal static void GetVolumesDetailsByDeviceIoControl(string volumeName)
        {
            IntPtr hVolume = CreateFile(
               volumeName,
               0,  // GENERIC_READ
               0,  // FILE_SHARE_READ | FILE_SHARE_WRITE
               IntPtr.Zero,
               3,  // OPEN_EXISTING
               0x00280000,  // FILE_FLAG_BACKUP_SEMANTICS
               IntPtr.Zero);

            if (hVolume == IntPtr.Zero || hVolume.ToInt32() == -1)
            {
                int errorCode = Marshal.GetLastWin32Error();
                Console.WriteLine("CreateFile failed. Error code: " + errorCode);
                return;
            }

            VOLUME_DISK_EXTENTS volumeDiskExtents = new VOLUME_DISK_EXTENTS();
            uint bytesReturned = 0;

            bool result = DeviceIoControl(
                hVolume,
                0x00070000,  // IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS
                IntPtr.Zero,
                0,
                ref volumeDiskExtents,
                (uint)Marshal.SizeOf(typeof(VOLUME_DISK_EXTENTS)),
                ref bytesReturned,
                IntPtr.Zero);

            if (result)
            {
                Console.WriteLine("Number of Disk Extents: " + volumeDiskExtents.NumberOfDiskExtents);
                foreach (var extent in volumeDiskExtents.Extents)
                {
                    Console.WriteLine($"Disk Number: {extent.DiskNumber}, Starting Offset: {extent.StartingOffset}, Extent Length: {extent.ExtentLength}");
                }
            }
            else
            {
                int errorCode = Marshal.GetLastWin32Error();
                Console.WriteLine("DeviceIoControl failed. Error code: " + errorCode);
            }

            //Console.ReadKey();
            CloseHandle(hVolume);
        }

        internal static DriveInfo GetDriveInfo(string rootPath)
        {
            DriveInfo driveInfo = new DriveInfo();

            StringBuilder volumeNameBuffer = new StringBuilder(256);
            StringBuilder fileSystemNameBuffer = new StringBuilder(256);

            uint volumeSerialNumber;
            uint maximumComponentLength;
            uint fileSystemFlags;

            if (GetVolumeInformation(
                rootPath,
                volumeNameBuffer,
                (uint)volumeNameBuffer.Capacity,
                out volumeSerialNumber,
                out maximumComponentLength,
                out fileSystemFlags,
                fileSystemNameBuffer,
                (uint)fileSystemNameBuffer.Capacity) != 0)
            {
                driveInfo.VolumeLabel = volumeNameBuffer.ToString();
                driveInfo.RootPath = rootPath;
                driveInfo.FileSystem = fileSystemNameBuffer.ToString();

                ulong freeBytesAvailable;
                ulong totalNumberOfBytes;
                ulong totalNumberOfFreeBytes;

                if (GetDiskFreeSpaceEx(
                    rootPath,
                    out freeBytesAvailable,
                    out totalNumberOfBytes,
                    out totalNumberOfFreeBytes))
                {
                    driveInfo.TotalSpace = totalNumberOfBytes;
                    driveInfo.FreeSpace = freeBytesAvailable;
                }
            }

            return driveInfo;
        }


    }
}
