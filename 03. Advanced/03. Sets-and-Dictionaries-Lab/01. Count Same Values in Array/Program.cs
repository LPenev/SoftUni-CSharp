double[] inputArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

Dictionary<double, int> dict = new Dictionary<double, int>();

foreach (var key in inputArray)
{
    if (!dict.ContainsKey(key))
    {
        dict.Add(key, 0);
    }

    dict[key]++;
}

foreach (var current in dict)
{
    Console.WriteLine($"{current.Key} - {current.Value} times");
}