using Serilog;

namespace Converter.CLI.CLIMessages
{
    internal static class MessagesWriter
    {
        public static void Info(string message)
        {
            Log.Information(message);
        }
        public static void Error(string message)
        {
            Log.Error(message);
        }
        public static void Warning(string message)
        {
            Log.Warning(message);
        }
    }
}
