
namespace NauticalCatchChallenge.Models
{
    internal class ScubaDiver : Diver
    {
        private const int OxygenLevel = 540;
        public ScubaDiver(string name) : base(name, OxygenLevel)
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
