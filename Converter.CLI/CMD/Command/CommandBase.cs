using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;

namespace Converter.CLI
{
    internal abstract class CommandBase
    {
        public abstract void OnExecute(CommandLineApplication app);
    }
}
