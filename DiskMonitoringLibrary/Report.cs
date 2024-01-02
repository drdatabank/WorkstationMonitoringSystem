using DiskMonitoringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using static DiskMonitoringLibrary.DiskMonitoring;


namespace DiskMonitoringLibrary
{
    internal abstract class Report : IReport
    {

        private List<Dictionary<string, string>> volumesData = new List<Dictionary<string, string>>();


        public Dictionary<string, string> ReportDictionary(IDriveInfo driveInfo)
        {
            Dictionary<string, string> volume = new Dictionary<string, string>();

            // Getting information about the type of an object
            Type type = driveInfo.GetType();
            // Retrieving an object field
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            // Display field names and their values
            foreach (FieldInfo field in fields)
            {
                var value = field.GetValue(driveInfo);
                //Console.WriteLine($"{field.Name}: {value}");
                volume.Add(field.Name.Replace("<","").Replace(">k__BackingField",""), value.ToString());
            }
            return volume;
        }

        public IEnumerable<Dictionary<string, string>> AllDisksReportAsDictionaryList()
        {
            foreach (string rootPath in GetVolumes())
            {
                volumesData.Add(ReportDictionary(GetDriveInfo(rootPath)));

            }
            return volumesData;
        }

    }   
}
