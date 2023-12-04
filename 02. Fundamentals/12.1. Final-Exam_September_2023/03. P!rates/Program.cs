namespace _03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var citys = new List<City>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Sail")
            {
                var inputArray = input.Split("||");
                string cityName = inputArray[0];
                int population = int.Parse(inputArray[1]);
                int gold = int.Parse(inputArray[2]);

                City currentCity = citys.FirstOrDefault(x=>x.CityName == cityName);
                
                if (currentCity != null)
                {
                    currentCity.Population += population;
                    currentCity.Gold += gold;
                }
                else
                {
                    citys.Add(new City(cityName, population, gold));
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArray = input.Split("=>");
                string command = inputArray[0];
                string town = inputArray[1];
                
                City currentCity = citys.FirstOrDefault(x => x.CityName == town);

                if ((currentCity != null) && (command == "Plunder"))
                {
                    int people = int.Parse(inputArray[2]);
                    int gold = int.Parse(inputArray[3]);
                    currentCity.Population -= people;
                    currentCity.Gold -= gold;
                    
                    if((currentCity.Gold > 0)&&(currentCity.Population > 0))
                    {
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    }
                    else
                    {
                        citys.Remove(currentCity);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if ((currentCity != null) && (command == "Prosper"))
                {
                    int gold = int.Parse(inputArray[2]);

                    currentCity.Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {currentCity.Gold} gold.");
                }
            }
            // print result
            Console.WriteLine($"Ahoy, Captain! There are {citys.Count} wealthy settlements to go to:");
            foreach ( City city in citys )
            {
                Console.WriteLine($"{city.CityName} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
            }
        }
    }
    public class City
    {
        public City(string cityName, int popultion, int gold)
        {
            this.CityName = cityName;
            this.Population = popultion;
            this.Gold = gold;
        }
        public string CityName { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
