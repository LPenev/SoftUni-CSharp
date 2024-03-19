
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
