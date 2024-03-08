using Telephony.Core.Interfaces;
using Telephony.Models.Interfaces;
using Telephony.Models;
using Telephony.IO.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] telephoneNumberArray = reader.ReadString()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] webAdressesArray = reader.ReadString()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable = null;

            foreach (string currentNumber in telephoneNumberArray)
            {
                if (currentNumber.Length == 7)
                {
                    callable = new StationaryPhone();
                }
                else if (currentNumber.Length == 10)
                {
                    callable = new Smartphone();
                }

                try
                {
                    writer.WriteLine(callable.Call(currentNumber));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            IBrowsable browsable;

            foreach (var webAdresses in webAdressesArray)
            {
                browsable = new Smartphone();

                try
                {
                    writer.WriteLine(browsable.Browse(webAdresses));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
