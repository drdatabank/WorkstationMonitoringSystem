using Microsoft.Extensions.Configuration;

namespace Server.Tools
{
    public class AppSettingsConfiguration
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "")))
            .AddJsonFile("appsettings.json")
            .Build(); ;
        }
    }
}
