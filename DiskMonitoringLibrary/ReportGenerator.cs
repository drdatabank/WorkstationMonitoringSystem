using DiskMonitoringLibrary.Models;

namespace DiskMonitoringLibrary
{
    public enum ReportType
    {
        YAML,
        JSON,
        XML
    }
    public static class ReportGenerator
    {
        /// <summary>
        /// Select appropriate enum 'ReportType' to get report in chosen format as a string
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        public static string GenerateReport(ReportType reportType)
        {
            IReportGenerator reportGenerator = null;
            switch (reportType)            
            {
                case ReportType.YAML:
                    reportGenerator = new ReportToYaml();
                    break;
                case ReportType.JSON:
                    reportGenerator = new ReportToJson();
                    break;
                case ReportType.XML:
                    reportGenerator = new ReportToXml();
                    break;
            }
            return reportGenerator.GenerateReport();
        }
    }
}
