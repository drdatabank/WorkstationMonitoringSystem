using System.Collections.Generic;

namespace DiskMonitoringLibrary.Models
{
    internal interface IReport
    {
        IEnumerable<Dictionary<string, string>> AllDisksReportAsDictionaryList();
        Dictionary<string, string> ReportDictionary(IDriveInfo driveInfo);
    }

    internal interface IReportGenerator : IReport
    {
        string GenerateReport();
    }
}