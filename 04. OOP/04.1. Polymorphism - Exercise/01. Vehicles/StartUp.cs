using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.VehicleFactory;
using Vehicles.VehicleFactory.Interfaces;

internal class StartUp
{
    private static void Main(string[] args)
    {
        IVehicleFactory vehicleFactory = new VehicleFactory();

        IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        engine.Start();
    }
}