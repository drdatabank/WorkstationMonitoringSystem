using NLog;

namespace Server.Logs
{
    internal class ServerLogger
    {
        public Logger Logger { get; set; }
        public Logger ReportLoger { get; set; }

        public ServerLogger() {
            LogManager.LoadConfiguration("../../../Logs/nlog.config");
            Logger = LogManager.GetCurrentClassLogger();
            ReportLoger = LogManager.GetLogger("Reports");  
        }   
    }
}
