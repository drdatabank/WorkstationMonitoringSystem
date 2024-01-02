using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Server.Tools;

namespace Server
{
    internal class ServerStream
    {
        private readonly WebApplicationBuilder webApplicationBuilder;

        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public ServerStream(WebApplicationBuilder webApplicationBuilder, Logger logger)
        {
            this.webApplicationBuilder = webApplicationBuilder;
            this.logger = logger;
            this.configuration= AppSettingsConfiguration.GetConfiguration();
        }

        public WebApplication CreateApp(string[] arg)
        {
            //var webApplicationBuilder = WebApplication.CreateBuilder(arg);

            webApplicationBuilder.Services.AddSignalR();
            webApplicationBuilder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials();
        });
       

                //options.AddPolicy("AllowAll",//"CorsPolicy", 
                //    builder => builder
                //    .WithOrigins(configuration["AppSettings:CorsPolicyHostAdress"])
                //    .AllowAnyMethod()
                //    .AllowAnyHeader()
                //    .AllowCredentials());
            });

            var app = webApplicationBuilder.Build();
            return app;
        }
        
    }
}
