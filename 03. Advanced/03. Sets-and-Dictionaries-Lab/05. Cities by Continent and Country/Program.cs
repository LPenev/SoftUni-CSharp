int countOfEntry = int.Parse(Console.ReadLine());

var continents = new Dictionary<string, Dictionary<string, List<string>>>();

// read from console and them into dictionary
for(int i = 0; i < countOfEntry; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string continent = input[0];
    string country = input[1];
    string city = input[2];

    if (!continents.ContainsKey(continent))
    {
        continents.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!continents[continent].ContainsKey(country))
    {
        continents[continent].Add(country, new List<string>());
    }
        
    continents[continent][country].Add(city);
}

// print result
foreach (var continent in continents)
{
    Console.WriteLine($"{continent.Key}:");

    foreach (var country in continent.Value)
    {
        Console.WriteLine($"  {country.Key} -> {string.Join(", ", continents[continent.Key][country.Key])}");
    }
}