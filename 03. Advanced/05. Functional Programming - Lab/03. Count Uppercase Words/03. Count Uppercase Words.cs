Func<string, bool> isStartWithUpper = x => Char.IsUpper(x[0]);

string[] words = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(isStartWithUpper)
    .ToArray();

Console.WriteLine(String.Join("\n", words));
