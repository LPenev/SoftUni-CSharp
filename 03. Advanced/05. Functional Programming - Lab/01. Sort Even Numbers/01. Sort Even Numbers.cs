int[] input = Console.ReadLine()
    .Split(", ")
    .Select(x => int.Parse(x))
    .Where(x => x % 2 == 0)
    .OrderBy(x => x)
    .ToArray();

// print result
Console.WriteLine(String.Join(", ", input));