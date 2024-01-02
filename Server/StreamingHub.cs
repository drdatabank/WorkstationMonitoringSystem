using DiskMonitoringLibrary;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using NLog;
using Server.Logs;
using Server.Tools;

class StreamingHub : Hub
{
    private Logger logger = new ServerLogger().Logger;
    private Logger reportLogger = new ServerLogger().ReportLoger;
    IConfiguration configuration { get; set; } = AppSettingsConfiguration.GetConfiguration();

    public async IAsyncEnumerable<string> Streaming(CancellationToken stoppingToken)
    {
            while (!stoppingToken.IsCancellationRequested)
            {           
                ReportType reportType;
                if (!ReportType.TryParse(configuration["AppSettings:ReportType"].ToUpper(), out reportType))
                {
                    reportType = ReportType.YAML;
                }
                var report = ReportGenerator.GenerateReport(reportType);
                Console.WriteLine(report.ToString());
                reportLogger.Info($"--Server disc report--" + Environment.NewLine + report);
                yield return report;           

                try
                {
                    await Task.Delay(int.Parse(configuration["AppSettings:SendingReportTimeSpan"]),
                        stoppingToken);
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    yield break;
                }

            }
        }

    }
