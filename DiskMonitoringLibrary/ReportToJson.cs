using DiskMonitoringLibrary.Models;
using Newtonsoft.Json;

namespace DiskMonitoringLibrary
{
    internal class ReportToJson : Report, IReportGenerator
    {
        public string GenerateReport()
        {
            return JsonConvert.SerializeObject(AllDisksReportAsDictionaryList());            
        }
    }
}
