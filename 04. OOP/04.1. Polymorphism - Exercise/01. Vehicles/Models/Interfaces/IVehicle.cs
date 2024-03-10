namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }

        public void Refuel(double amount);
        public string Drive(double distance);
    }
}
