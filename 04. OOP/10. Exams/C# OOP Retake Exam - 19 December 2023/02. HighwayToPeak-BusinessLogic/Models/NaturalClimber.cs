namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int StaminaConstant = 6;

        public NaturalClimber(string name) : base(name, StaminaConstant)
        {
        }

        public override void Rest(int daysCount)
        {
            int recoverProDay = 2;
            Stamina += daysCount * recoverProDay;
        }
    }
}
