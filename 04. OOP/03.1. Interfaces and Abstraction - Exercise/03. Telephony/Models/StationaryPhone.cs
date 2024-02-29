using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string TelNummer { get; private set; }

        public string Call(string telefonNumber)
        {
            this.TelNummer = telefonNumber;

            return $"Dialing... {TelNummer}";
        }
    }
}
