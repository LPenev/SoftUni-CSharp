namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int OxygenLevel_Const = 120;

        public FreeDiver(string name) : base(name, OxygenLevel_Const)
        {
        }

        public override void Miss(int timeToCatch)
        {
            OxygenLevel -= (int)Math.Round(timeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = OxygenLevel_Const;
        }
    }
}
