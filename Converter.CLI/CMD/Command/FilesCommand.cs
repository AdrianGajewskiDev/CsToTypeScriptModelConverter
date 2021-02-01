using Converter.CLI.CLIMessages;
using Converter.CLI.Factories;
using Converter.CLI.Files;
using Converter.Core.Converter;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Converter.CLI.CMD.Command
{
    [Command(names: new string[] {"file", "f"})]
    internal class FilesCommand : CommandBaseAync<ConverterCmd>
    {
        public override ConverterCmd Parent { get; set; }

        [Option(template: "--dir", CommandOptionType.SingleValue)]
        public string SpecifiedDirectory { get; set; }

        [Option(template: "--out", CommandOptionType.SingleValue)]
        public string OutputDirectory { get; set; }

        private IFilesManager _manager;

        private readonly CTSConverter _converter;

        public FilesCommand(CTSConverter converter)
        {
            _manager = FilesManagerFactory.Create();
            _converter = converter;
        }

        public override async Task OnExecuteAsync(CommandLineApplication app)
        {
            if(string.IsNullOrEmpty(SpecifiedDirectory) || !Directory.Exists(SpecifiedDirectory))
            {
                MessagesWriter.Error("You must specify a valid directory");
                return;
            }

            var files = _manager.GetFiles(SpecifiedDirectory, ".cs");

            List<CodeFile> codesInText = new List<CodeFile>();

            foreach (var file in files)
            {
                MessagesWriter.Info($"Reading code from {file.Name}...");
                var code = await _manager.ReadCodeAsync(file.FullName);
                codesInText.Add(new CodeFile(file.Name, code, ".ts"));
            }


            if(codesInText.Count > 0)
            {
                foreach (var code in codesInText)
                {
                    MessagesWriter.Info($"Converting the {code.FileName}...");
                    var convertedCode = _converter.Convert(code.Code);
                    code.SwapCode(convertedCode);
                }
            }

            int progress = 0;
            int all = codesInText.Count;
            for (int i = 0; i < codesInText.Count; i++)
            {
                progress = i + 1;
                var code = codesInText[i];
                var savePath = Path.Combine(SpecifiedDirectory, code.FullName);
                await _manager.SaveToFileAsync(code.Code,savePath);
                MessagesWriter.Info($"Saving [{progress}/{all}]...");
            }
            MessagesWriter.Info($"Done");

        }
    }
}
