namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private double DefaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        
        public double FuelConsumption => DefaultFuelConsumption;

        public void Drive(double kilometers)
        {
            Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
