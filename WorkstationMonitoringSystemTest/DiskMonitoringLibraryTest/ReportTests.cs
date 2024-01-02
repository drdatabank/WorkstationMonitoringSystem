using DiskMonitoringLibrary;
using DiskMonitoringLibrary.Models;
using WorkstationMonitoringSystemTest.DiskMonitoringLibraryTest.Mocks;

namespace WorkstationMonitoringSystemTest.DiskMonitoringLibraryTest
{
    [TestFixture]
    public class ReportTests
    {
        [Test]
        [TestCaseSource(nameof(DriveInfoMockGetCorrectDriveInfo))]
        public void ReportDictionary_ReturnsCorrectDictionary(IDriveInfo driveInfo)
        {
            // Arrange
            Report report = new ReportMock();
            
            // Act
            Dictionary<string, string> result = report.ReportDictionary(driveInfo);
            int totalSpace;
            bool totalSpaceParseResult = int.TryParse(result["TotalSpace"], out totalSpace);
            int freeSpace;
            bool freeSpaceParseResult = int.TryParse(result["FreeSpace"], out freeSpace);


            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.IsTrue(totalSpaceParseResult);
            Assert.IsTrue(freeSpaceParseResult);
            Assert.IsTrue(totalSpace > freeSpace);
            Assert.IsTrue(int.Parse(result["TotalSpace"]) > 0);
            Assert.IsTrue(result.Keys.Count > 0);

        }

        [Test]
        public void AllDisksReportAsDictionaryList_ReturnsNonEmptyList()
        {
            // Arrange
            Report report = new ReportMock();

            // Act
            IEnumerable<Dictionary<string, string>> resultList = report.AllDisksReportAsDictionaryList();

            // Assert
            Assert.IsNotNull(resultList);
            Assert.IsNotEmpty(resultList);
            Assert.IsTrue(resultList.Any());
        }


        private static IEnumerable<DriveInfoMock> DriveInfoMockGetCorrectDriveInfo()
        {
            return DriveInfoMock.GetCorrectDriveInfo();
        }
        
    }    
}
