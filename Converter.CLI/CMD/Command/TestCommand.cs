using Converter.CLI.CLIMessages;
using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;

namespace Converter.CLI
{
    [Command("Test")]
    internal class TestCommand : CommandBase
    {

        public override void OnExecute(CommandLineApplication app)
        {
            MessagesWriter.Error("Test");
        }
    }
}
