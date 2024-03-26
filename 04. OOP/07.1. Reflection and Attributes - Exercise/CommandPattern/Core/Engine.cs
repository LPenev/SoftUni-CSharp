
using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandIntepreter;

        public Engine(ICommandInterpreter commandIntepreter)
        {
            this.commandIntepreter = commandIntepreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    string result = commandIntepreter.Read(input);
                    Console.WriteLine(result);

                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
