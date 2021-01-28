using Serilog;
using Serilog.Configuration;

namespace Converter.CLI.Configuration
{
    public class LoggerSettings : ILoggerSettings
    {
        public void Configure(LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration
                .WriteTo.Console().
                Enrich.FromLogContext();
        }
    }
}
