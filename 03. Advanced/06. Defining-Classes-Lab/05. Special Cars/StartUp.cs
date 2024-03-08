namespace CarManufacturer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int tireOneYear = int.Parse(inputArray[0]);
                double tireOnePressure = double.Parse(inputArray[1]);
                int tireTwoYear = int.Parse(inputArray[2]);
                double tireTwoPressure = double.Parse(inputArray[3]);
                int tireThreeYear = int.Parse(inputArray[4]);
                double tireThreePressure = double.Parse(inputArray[5]);
                int tireVierYear = int.Parse(inputArray[6]);
                double tireVierPressure = double.Parse(inputArray[7]);

                Tire tireOne = new(tireOneYear, tireOnePressure);
                Tire tireTwo = new(tireTwoYear, tireTwoPressure);
                Tire tireThree = new(tireThreeYear, tireThreePressure);
                Tire tireVier = new(tireVierYear, tireVierPressure);

                Tire[] carTires = { tireOne, tireTwo, tireThree, tireVier };

                tires.Add(carTires);
            }

            List<Engine> engines = new List<Engine>();

            while((input = Console.ReadLine()) != "Engines done")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(inputArray[0]);
                double cubicCapacity = double.Parse(inputArray[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> cars = new List<Car>();

            while((input = Console.ReadLine()) != "Show special")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = inputArray[0];
                string model = inputArray[1];
                int year = int.Parse(inputArray[2]);
                double fuelQuanitity = double.Parse(inputArray[3]);
                double fuelConsumpation = double.Parse(inputArray[4]);
                int engineIndex = int.Parse(inputArray[5]);
                int tiresIndex = int.Parse(inputArray[6]);

                cars.Add(new Car(make, model, year, fuelQuanitity, fuelConsumpation, engineIndex, tiresIndex));
            }

            var selectedCars = cars.Where(x => x.Year >= 2017)
                .Where(x => engines[x.EngineIndex].HorsePower > 330)
                .Where(x => tires[x.TiresIndex].Sum(p => p.Pressure) >= 9 && tires[x.TiresIndex].Sum(p => p.Pressure) <= 10);

            foreach(var currentCar in selectedCars)
            {
                currentCar.Drive(20);
                Console.WriteLine(currentCar.WhoAmI(engines));
            }
            
        }
    }
}
