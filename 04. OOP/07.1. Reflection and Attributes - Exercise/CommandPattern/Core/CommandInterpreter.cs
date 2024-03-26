using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private string CommndNotFound = "Command not found.";

        public string Read(string args)
        {

            string[] inputArray = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = inputArray[0];
            string[] commandArgs = inputArray.Skip(1).ToArray();

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException(CommndNotFound);
            }

            ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;
            string result = commandInstance.Execute(commandArgs);

            return result.ToString();
        }
    }
}
