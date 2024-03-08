using System.Xml.Schema;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int countEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < countEngines; i++)
            {
                string[] engineArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = CreateEngine(engineArray);
                engines.Add(engine);
            }

            int countCars = int.Parse(Console.ReadLine());
            
            for(int i = 0;i < countCars; i++)
            {
                string[] carArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = CreateCar(carArray, engines);
                cars.Add(car);
            }

            foreach(var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        static Engine CreateEngine(string[] engineProperties)
        {
            string model = engineProperties[0];
            int power = int.Parse(engineProperties[1]);

            Engine engine = new(model, power);

            if (engineProperties.Length > 2)
            {
                int displement = 0;
                bool isDigit = int.TryParse(engineProperties[2], out displement);

                if(isDigit)
                {
                    engine.Displacement = displement;
                }
                else
                {
                    engine.Efficiency = engineProperties[2];
                }

                if(engineProperties.Length > 3)
                {
                    engine.Efficiency = engineProperties[3];
                }
            }

            return engine;
        }
        static Car CreateCar(string[] carProperties, List<Engine> engines)
        {
            Engine engine = engines.Find(x=> x.Model == carProperties[1]);
            Car car = new(carProperties[0], engine);

            if (carProperties.Length > 2)
            {
                int weight = 0;
                bool isDigit = int.TryParse(carProperties[2], out weight);

                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carProperties[2];
                }

                if(carProperties.Length > 3)
                {
                    car.Color = carProperties[3];
                }
            }
            return car;
        }
    }
}
