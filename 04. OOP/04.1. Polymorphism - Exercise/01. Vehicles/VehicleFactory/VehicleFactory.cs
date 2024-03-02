using Vehicles.Models;
using Vehicles.Models.Interfaces;
using Vehicles.VehicleFactory.Interfaces;

namespace Vehicles.VehicleFactory
{
    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {
            
        }

        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            if (type == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption);
            }
            else if(type == "Truck")
            {
                return new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new ArgumentException("Invalid vehicle type.");
            }
        }
    }
}
