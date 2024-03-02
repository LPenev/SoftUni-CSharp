﻿using System.Reflection.PortableExecutable;
using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;
using Vehicles.VehicleFactory;
using Vehicles.VehicleFactory.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new HashSet<IVehicle>();
        }

        public void Start()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }
        private IVehicle CreateVehicle()
        {
            string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));
        }
        private void ProcessCommand()
        {
            string[] commandArray = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandArray[0];
            string vehicleType = commandArray[1];

            IVehicle? vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandArray[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(commandArray[2]);
                vehicle.Refuel(fuelAmount);
            }
        }
    }
}
