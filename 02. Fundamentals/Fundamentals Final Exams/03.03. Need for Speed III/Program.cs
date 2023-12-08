namespace _03._03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            var linesCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < linesCount; i++)
            {
                var inputArray = Console.ReadLine().Split("|");
                var name = inputArray[0];
                var mileage = int.Parse(inputArray[1]);
                var fuel = int.Parse(inputArray[2]);
                var currentCar = new Car(name, mileage, fuel);
                cars.Add(currentCar);
            }

            var input = string.Empty;
            while((input = Console.ReadLine()) != "Stop")
            {
                var inputArray = input.Split(" : ");
                var command = inputArray[0];
                var carName = inputArray[1];

                var currentAuto = cars.FirstOrDefault(x => x.Name == carName);

                switch (command)
                {
                    case "Drive":
                        var distance = int.Parse(inputArray[2]);
                        var fuel = int.Parse(inputArray[3]);

                        break;

                    case "Refuel":
                        var fuelToRefeul = int.Parse(inputArray[2]);

                        break;

                    case "Revert":
                        var kilometersToRevert = int.Parse(inputArray[2]);

                        break;

                }
            }
        }

        public class Car
        {
            public Car(string name, int mileage, int fuel)
            {
                this.Name = name;
                this.Mileage = mileage;
                this.Fuel = fuel;
            }
            public string Name { get; set; }
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
    }
}
