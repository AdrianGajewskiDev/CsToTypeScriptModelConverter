using Converter.CLI.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Converter.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string basePath = Directory.GetCurrentDirectory();

            var Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(Path.Combine(basePath, "appsettings.json"), false, true)
                .Build();


            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Settings(new LoggerSettings())
                .CreateLogger();
                

            var host = new HostBuilder().ConfigureServices((context, services) => 
            {
                services.AddLogging(conf => 
                {
                    conf.AddProvider(new SerilogLoggerProvider(Log.Logger));
                    var minLevel = Configuration.GetSection("Serilog:MinLogLevel")?.Value;

                    if(!string.IsNullOrEmpty(minLevel))
                        conf.SetMinimumLevel(Enum.Parse<LogLevel>(minLevel));
                });
            })
            .Build();

            try
            {
                Log.Information("Starting application...");
                await host.RunAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
