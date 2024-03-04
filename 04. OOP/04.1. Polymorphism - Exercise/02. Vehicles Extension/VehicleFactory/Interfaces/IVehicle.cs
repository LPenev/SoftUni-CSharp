using Vehicles.Models.Interfaces;

namespace Vehicles.VehicleFactory.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption);
    }
}
