Catalog catalog = new Catalog();

string input = Console.ReadLine();

while (input != "end")
{
    string[] infoArray = input.Split("/");
    string type = infoArray[0];
    string brand = infoArray[1];
    string model = infoArray[2];
    int weightOrHoursPower = int.Parse(infoArray[3]);

    if (type == "Truck")
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
        car.HoursePower = weightOrHoursPower;
        catalog.Cars.Add(car);
    }

    input = Console.ReadLine();
}

Console.WriteLine("Cars:");
foreach (Car currentCar in catalog.Cars.OrderBy(x => x.Brand))
{
    Console.WriteLine($"{currentCar.Brand}: {currentCar.Model} - {currentCar.HoursePower}hp");
}

Console.WriteLine("Trucks:");
foreach (Truck currentTruck in catalog.Trucks.OrderBy(x => x.Brand))
{
    Console.WriteLine($"{currentTruck.Brand}: {currentTruck.Model} - {currentTruck.Weight}kg");
}



class Truck
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }
}
class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int HoursePower { get; set; }
}

class Catalog
    {
        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }

    public List<Truck> Trucks { get; set; }
    public List<Car> Cars { get; set; }
}