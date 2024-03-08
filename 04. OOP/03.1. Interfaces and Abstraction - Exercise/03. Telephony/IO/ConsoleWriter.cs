using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    internal class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}
