Func<string,int> parseStringToInt = x => int.Parse(x);

int[] input = Console.ReadLine()
    .Split(", ")
    .Select(parseStringToInt)
    .ToArray();

Console.WriteLine(input.Count());
Console.WriteLine(input.Sum());
