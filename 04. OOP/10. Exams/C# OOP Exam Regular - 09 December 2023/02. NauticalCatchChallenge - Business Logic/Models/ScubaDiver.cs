namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int OxygenLevel_Const = 540;

        public ScubaDiver(string name) : base(name, OxygenLevel_Const)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.3, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = OxygenLevel_Const;
        }
    }
}
