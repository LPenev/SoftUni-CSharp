namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int StaminaConstant = 10;

        public OxygenClimber(string name) : base(name, StaminaConstant)
        {
        }

        public override void Rest(int daysCount)
        {
            int recoverProDay = 1;
            Stamina += daysCount * recoverProDay;
        }
    }
}
