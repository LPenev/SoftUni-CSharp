namespace _02._03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var plants = new Dictionary<string, int>();
            var ratings = new Dictionary<string, List<double>>();

            var countLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLine; i++)
            {
                var inputArray = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                var plant = inputArray[0];
                var rarity = int.Parse(inputArray[1]);

                if (plants.ContainsKey(plant))
                {
                    plants[plant] = rarity;
                }
                else
                {
                    plants.Add(plant, rarity);
                    ratings.Add(plant, new List<double>());
                }
            }

            var input = string.Empty;
            while((input = Console.ReadLine()) != "Exhibition")
            {
                var command = input.Split(":",StringSplitOptions.RemoveEmptyEntries);
                var plantArray = command[1].Trim().Split("-");
                var plant = plantArray[0].Trim();

                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (command[0])
                {
                    case "Rate":
                        var rating = double.Parse(plantArray[1].Trim());
                        ratings[plant].Add(rating);
                        break;

                    case "Update":
                        var newRarity = int.Parse(plantArray[1].Trim());
                        plants[plant] = newRarity;
                        break;

                    case "Reset":
                        ratings[plant].Clear();
                        break;
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach(var plant in plants)
            {
                var averageRating = ratings[plant.Key].Count() > 0 ? ratings[plant.Key].Average(): 0.0;
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value}; Rating: {averageRating:f2}");
            }
        }
    }
}
