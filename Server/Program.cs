using Microsoft.AspNetCore.Builder;
using NLog;
using Server;
using Server.Logs;
using Server.Tools;

Logger logger = new ServerLogger().Logger;
try
{
    var configuration = AppSettingsConfiguration.GetConfiguration();
    WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
    ServerStream serverStream = new ServerStream(webApplicationBuilder, logger);
    var app = serverStream.CreateApp(args);
    app.UseCors("CorsPolicy");
    app.MapHub<StreamingHub>(configuration["AppSettings:StreamingHubEndpointPatternForDiskRepors"]);
    //app.MapHub<ChartHub>("/chat");
    logger.Info("Hubs have been prepared");
    //app.UseCors("AllowAll");//"CorsPolicy");
    
   
    app.Run();
}
catch (Exception e)
{
    logger.Error(e.Message);
}

