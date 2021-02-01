using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Converter.CLI
{
    internal abstract class CommandBase<T>
    {
        public abstract T Parent { get; set; }
        public virtual void Execute() { }
    }

    internal abstract class CommandBaseAync<T> : CommandBase<T>
    {
        public virtual Task OnExecuteAsync(CommandLineApplication app)
        {
            return Task.CompletedTask;
        }
    }
}
