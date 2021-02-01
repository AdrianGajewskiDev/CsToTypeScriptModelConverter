using Converter.CLI.CLIMessages;
using Converter.CLI.Factories;
using Converter.CLI.Files;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Converter.CLI.CMD.Command
{
    [Command(names: new string[] {"file", "f"})]
    internal class FilesCommand : CommandBase<ConverterCmd>
    {
        public override ConverterCmd Parent { get; set; }

        [Option(template: "--dir", CommandOptionType.SingleValue)]
        public string SpecifiedDirectory { get; set; }

        private IFilesManager _manager;

        public FilesCommand()
        {
            _manager = FilesManagerFactory.Create();
        }

        public override void OnExecute(CommandLineApplication app)
        {
            if(string.IsNullOrEmpty(SpecifiedDirectory) || !Directory.Exists(SpecifiedDirectory))
            {
                MessagesWriter.Error("You must specify a valid directory");
                return;
            }

            var files = _manager.GetFiles(SpecifiedDirectory, ".cs");

            foreach (var file in files)
            {
               
            }
        }
    }
}
