
namespace NauticalCatchChallenge.Models
{
    internal class FreeDiver : Diver
    {
        private const int OxygenLevel = 120;
        public FreeDiver(string name) : base(name, OxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            throw new NotImplementedException();
        }

        public override void RenewOxy()
        {
            throw new NotImplementedException();
        }
    }
}
