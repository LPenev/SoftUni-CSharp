
int[] numbersArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .OrderByDescending(x=>x)
    .Take(3)
    .ToArray();

Console.WriteLine(string.Join(" ", numbersArray));