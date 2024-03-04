using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.IO;
using Vehicles.VehicleFactory;

public class StartUp
{
    private static void Main()
    {
        IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new VehicleFactory());
        engine.Start();
    }
}