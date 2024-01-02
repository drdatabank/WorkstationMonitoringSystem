using DiskMonitoringLibrary.Models;
using Newtonsoft.Json;
using System.Text;
using System.Xml;

namespace DiskMonitoringLibrary
{
    internal class ReportToXml : Report, IReportGenerator
    {
        public string GenerateReport()
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var report in AllDisksReportAsDictionaryList()) {
                counter++;
                XmlDocument doc = new XmlDocument();
                var json = JsonConvert.SerializeObject(report);
                doc = JsonConvert.DeserializeXmlNode($"{{ \"disk{counter}\": {json} }}");
                sb.Append(doc.OuterXml);
            }
            return sb.ToString();

        }
    }
}
