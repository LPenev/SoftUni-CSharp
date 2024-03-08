namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArray[0];
                int speed = int.Parse(inputArray[1]);
                int power = int.Parse(inputArray[2]);
                int weight = int.Parse(inputArray[3]);
                string cargoType = inputArray[4];

                double pressure0 = double.Parse(inputArray[5]);
                int age0 = int.Parse(inputArray[6]);

                double pressure1 = double.Parse(inputArray[7]);
                int age1 = int.Parse(inputArray[8]);

                double pressure2 = double.Parse(inputArray[9]);
                int age2 = int.Parse(inputArray[10]);

                double pressure3 = double.Parse(inputArray[11]);
                int age3 = int.Parse(inputArray[12]);

                cars.Add(new Car(model, speed, power, weight, cargoType, pressure0, age0, pressure1, age1, pressure2, age2, pressure3, age3));
            }

            string filterType = Console.ReadLine();
            IEnumerable<Car> filtredCars = null;

            if (filterType == "fragile")
            {
                filtredCars = cars.Where(x => x.Cargo.CargoType == filterType).Where(t => t.Tires.Any(z=>z.TirePressure < 1));
            }
            else if (filterType == "flammable")
            {
                filtredCars = cars.Where(x => x.Cargo.CargoType == filterType).Where(e=>e.Engine.Power > 250);
            }

            foreach (var car in filtredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
