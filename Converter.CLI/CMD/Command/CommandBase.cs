using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;

namespace Converter.CLI
{
    internal abstract class CommandBase<T>
    {
        public abstract T Parent { get; set; }
        public abstract void OnExecute(CommandLineApplication app);
    }
}
