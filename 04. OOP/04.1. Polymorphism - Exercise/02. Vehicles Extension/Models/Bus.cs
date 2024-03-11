namespace Vehicles.Models
{
    internal class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumtion, double increasedConsumption = 0)
            : base(fuelQuantity, fuelConsumtion, increasedConsumption)
        {
        }
    }
}
