using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace LineBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetupLogEnvironment(Path.GetFullPath(".\\logs\\LineBotWebService.log"));
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();

        private static void SetupLogEnvironment(string logFilePath)
        {
            LoggerConfiguration logConfig = new LoggerConfiguration();
            logConfig.MinimumLevel.Debug()
                     .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                     .Enrich.FromLogContext()
                     .WriteTo.Console()
                     .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day);
            Log.Logger = logConfig.CreateLogger();
        }
    }
}
