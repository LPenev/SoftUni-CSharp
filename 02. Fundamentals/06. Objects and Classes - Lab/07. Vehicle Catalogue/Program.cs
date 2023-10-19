using System.Reflection;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] infoArray = input.Split("/");
                string type = infoArray[0];
                string brand = infoArray[1];
                string model = infoArray[2];
                int weightOrHoursPower = int.Parse(infoArray[3]);

                if(type == "Truck")
                {
                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weightOrHoursPower;

                    catalog.Trucks.Add(truck);
                }
                else
                {
                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = weightOrHoursPower;

                    catalog.Cars.Add(car);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Cars:");
            foreach (Car current in catalog.Cars.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{current.Brand}: {current.Model} - {current.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (Truck current in catalog.Trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{current.Brand}: {current.Model} - {current.Weight}kg");
            }
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    public class Catalog
    {
        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }

        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}