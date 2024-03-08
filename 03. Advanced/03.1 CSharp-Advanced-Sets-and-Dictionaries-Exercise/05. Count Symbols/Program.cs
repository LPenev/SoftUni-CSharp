SortedDictionary<char, int> charCounts = new();

char[] inputArray = Console.ReadLine().ToCharArray();
foreach (char current in inputArray)
{
    if (!charCounts.ContainsKey(current))
    {
        charCounts.Add(current, 0);
    }
    charCounts[current]++;
}

foreach (var current in charCounts)
{
    Console.WriteLine($"{current.Key}: {current.Value} time/s");
}
