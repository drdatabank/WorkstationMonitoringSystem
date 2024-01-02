using NLog;

namespace Client.Logs
{
    internal class ClientLogger
    {
        public Logger Logger { get; set; }
        public Logger ReportLoger { get; set; }

        public ClientLogger()
        {
            LogManager.LoadConfiguration("../../../Logs/nlog.config");
            Logger = LogManager.GetCurrentClassLogger();
            ReportLoger = LogManager.GetLogger("Reports");

        }
    }
}
