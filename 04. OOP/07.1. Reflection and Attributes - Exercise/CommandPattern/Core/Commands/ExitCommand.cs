using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand : ICommand
    {
        private const int DefaultExitLevel = 0;

        public string Execute(string[] args)
        {
            Environment.Exit(DefaultExitLevel);
            return default;
        }
    }
}
