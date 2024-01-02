using DiskMonitoringLibrary.Models;
using System;
using System.Text;

namespace DiskMonitoringLibrary
{
    internal class ReportToYaml : Report, IReportGenerator
    {
        public string GenerateReport()
        {
            var result = new StringBuilder();
            foreach (var dictionary in AllDisksReportAsDictionaryList())
            {
                foreach (var pair in dictionary)
                {
                    result.AppendLine($"{pair.Key}: {pair.Value}");
                    
                }
                result.Append(Environment.NewLine);
            }
            return result.ToString();
        }
    }
}
