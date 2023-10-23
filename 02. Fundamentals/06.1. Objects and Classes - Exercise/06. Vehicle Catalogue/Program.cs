using System.Text;

namespace _11._06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleInfo[0];
                string model = vehicleInfo[1];
                string colorOfVehicle = vehicleInfo[2];
                int horsepowerOfVehicle = int.Parse(vehicleInfo[3]);

                Vehicle currentVehicle = new Vehicle(type, model, colorOfVehicle, horsepowerOfVehicle);
                vehicles.Add(currentVehicle);
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle currentVehicle = vehicles.Find(x => x.Model == input);
                Console.WriteLine(currentVehicle);
            }
            
            double sumCarsHorsepower = vehicles.Where(x => x.Type == "car").Sum(x => x.HorsepowerOfVehicle);
            if (sumCarsHorsepower > 0)
            {
                double avgCarsHoursepower = sumCarsHorsepower / vehicles.Where(x => x.Type == "car").Count();
                Console.WriteLine($"Cars have average horsepower of: {avgCarsHoursepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            double sumTrucksHoursepower = vehicles.Where(vehicles => vehicles.Type == "truck").Sum(vehicles => vehicles.HorsepowerOfVehicle);
            if (sumTrucksHoursepower > 0)
            {
                double avgTrucksHoursepower = sumTrucksHoursepower / vehicles.Where(x => x.Type == "truck").Count();
                Console.WriteLine($"Trucks have average horsepower of: {avgTrucksHoursepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }

        public class Vehicle
        {
            public Vehicle(string type, string model, string colorOfVehicle, int horsepowerOfVehicle)
            {
                this.Type = type;
                this.Model = model;
                this.ColorOfVehicle = colorOfVehicle;
                this.HorsepowerOfVehicle = horsepowerOfVehicle;
            }
            public string Type { get; set; }
            public string Model { get; set; }
            public string ColorOfVehicle { get; set; }
            public int HorsepowerOfVehicle { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Type: {(this.Type == "car" ? "Car" : "Truck")}");
                sb.AppendLine($"Model: {this.Model}");
                sb.AppendLine($"Color: {this.ColorOfVehicle}");
                sb.AppendLine($"Horsepower: {this.HorsepowerOfVehicle}");
                return sb.ToString().TrimEnd('\n');
            }
        }
    }
}