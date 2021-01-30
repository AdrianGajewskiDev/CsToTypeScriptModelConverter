using McMaster.Extensions.CommandLineUtils;
using System.Threading.Tasks;

namespace Converter.CLI.CMD
{
    [Command(Name = "cts", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    [Subcommand(typeof(TestCommand))]
    public class ConverterCmd
    {
        public Task<int> OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();

            return Task.FromResult(1);
        }
    }
}
