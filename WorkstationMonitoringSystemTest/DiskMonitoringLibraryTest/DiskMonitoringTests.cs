namespace WorkstationMonitoringSystemTest.DiskMonitoringLibraryTest
{
    using DiskMonitoringLibrary;
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    public class DiskMonitoringTests
    {
        [Test]
        public void GetVolumes_ReturnsAtLeastOneVolume()
        {
            // Act
            var volumes = DiskMonitoring.GetVolumes();

            // Assert
            Assert.IsNotNull(volumes);
            Assert.IsTrue(volumes.Any());
        }

        [Test]
        public void GetDriveInfo_ReturnsDriveInfoForValidPath()
        {
            // Arrange
            string rootPath = Path.GetPathRoot(Environment.CurrentDirectory);

            // Act
            var driveInfo = DiskMonitoring.GetDriveInfo(rootPath);

            // Assert
            Assert.IsTrue(driveInfo.TotalSpace != 0);
            //Assert.AreEqual(rootPath, driveInfo.RootDirectory.FullName);
        }

        [Test]
        public void GetDriveInfo_ThrowsExceptionForInvalidPath()
        {
            // Arrange
            string invalidPath = "InvalidPath:";
            var result = DiskMonitoring.GetDriveInfo(invalidPath);

            // Act & Assert
            Assert.IsTrue(result.TotalSpace == 0);
        }
    }

}
