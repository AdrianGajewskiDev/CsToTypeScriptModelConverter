using Converter.CLI.CLIMessages;
using McMaster.Extensions.CommandLineUtils;
using System.IO;

namespace Converter.CLI.CMD.Command
{
    [Command(names: new string[] {"file", "f"})]
    internal class FilesCommand : CommandBase<ConverterCmd>
    {
        public override ConverterCmd Parent { get; set; }

        [Option(template: "--dir", CommandOptionType.SingleValue)]
        public string SpecifiedDirectory { get; set; }

        public override void OnExecute(CommandLineApplication app)
        {
            if(string.IsNullOrEmpty(SpecifiedDirectory) || !Directory.Exists(SpecifiedDirectory))
            {
                MessagesWriter.Error("You must specify a valid directory");
                return;
            }

            var files = Directory.GetDirectories(SpecifiedDirectory);

            foreach (var file in files)
            {
                MessagesWriter.Info(file);
            }
        }
    }
}
