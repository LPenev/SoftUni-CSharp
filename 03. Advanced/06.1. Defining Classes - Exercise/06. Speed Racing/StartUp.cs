namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            int carCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < carCount; i++)
            {
                string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArray[0];
                double fuelAmount = double.Parse(inputArray[1]);
                double fuelConsumptionFor1Km = double.Parse(inputArray[2]);
                var currentCar = new Car(model, fuelAmount, fuelConsumptionFor1Km);
                car.AddCar(currentCar);
            }

            string input = string.Empty;
            
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = inputArray[1];
                int carDistance = int.Parse(inputArray[2]);
                car.Drive(carModel, carDistance);
            }

            car.PrintCars();
        }
    }
}
