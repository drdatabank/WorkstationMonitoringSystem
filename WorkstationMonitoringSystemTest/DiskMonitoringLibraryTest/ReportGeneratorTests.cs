using DiskMonitoringLibrary;


namespace WorkstationMonitoringSystemTest.DiskMonitoringLibraryTest
{

    [TestFixture]
    public class ReportGeneratorTests
    {
        [Test]
        public void GenerateReport_ReturnsValidJsonReport()
        {
            // Arrange
            ReportType reportType = ReportType.JSON;

            // Act
            string result = ReportGenerator.GenerateReport(reportType);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0); 
            Assert.IsTrue(result.Contains("TotalSpace"));
            Assert.IsTrue(result.Contains("\"TotalSpace\":"));
        }

        [Test]
        public void GenerateReport_ReturnsValidYamlReport()
        {
            // Arrange
            ReportType reportType = ReportType.YAML;

            // Act
            string result = ReportGenerator.GenerateReport(reportType);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
            Assert.IsTrue(result.Contains("TotalSpace"));
        }

        [Test]
        public void GenerateReport_ThrowsExceptionForXmlReportType()
        {
            // Arrange
            ReportType reportType = ReportType.XML;

            // Act
            string result = ReportGenerator.GenerateReport(reportType);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
            Assert.IsTrue(result.Contains("<TotalSpace>"));
            Assert.IsTrue(result.Contains("</TotalSpace>"));
        }
    }

}
