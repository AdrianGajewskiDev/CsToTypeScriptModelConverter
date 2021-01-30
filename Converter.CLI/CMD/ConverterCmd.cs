using Converter.CLI.CMD.Command;
using McMaster.Extensions.CommandLineUtils;
using System.Threading.Tasks;

namespace Converter.CLI.CMD
{
    [Command(Name = "cts", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    [Subcommand(typeof(FilesCommand))]
    public class ConverterCmd
    {
        public Task<int> OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();

            return Task.FromResult(1);
        }
    }
}
