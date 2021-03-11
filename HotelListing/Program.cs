using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Debug(new RenderedCompactJsonFormatter())
                .WriteTo.File("log.txt",rollingInterval:RollingInterval.Day)
                .CreateLogger();
            try
            {
                Log.Information("Starting web Host");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "an error found");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            //.ConfigureLogging(loggingBuilder =>
            //{
            //    loggingBuilder.ClearProviders();
            //    loggingBuilder.AddDebug()
            //    .AddEventLog();
            //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   
                    webBuilder.UseStartup<Startup>();
                });
    }
}
