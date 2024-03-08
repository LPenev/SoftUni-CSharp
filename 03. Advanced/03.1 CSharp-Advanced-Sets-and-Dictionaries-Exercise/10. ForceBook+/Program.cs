string input = string.Empty;
SortedDictionary<string, SortedSet<string>> forceSides = new();

while ((input = Console.ReadLine()) != "Lumpawaroo")
{
    if (input.Contains(" | "))
    {
        string[] inputArray = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
        string forceSide = inputArray[0];
        string username = inputArray[1];

        if (!forceSides.Values.Any(x => x.Contains(username)))
        {
            if (!forceSides.ContainsKey(forceSide))
            {
                forceSides.Add(forceSide, new SortedSet<string>());
            }
            forceSides[forceSide].Add(username);
        }
    }
    else if (input.Contains(" -> "))
    {
        string[] inputArray = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
        string username = inputArray[0];
        string forceSide = inputArray[1];

        foreach (var side in forceSides)
        {
            if (side.Value.Contains(username))
            {
                forceSides[side.Key].Remove(username);
                break;
            }
        }

        if (!forceSides.ContainsKey(forceSide))
        {
            forceSides.Add(forceSide, new SortedSet<string>());
        }

        forceSides[forceSide].Add(username);
        Console.WriteLine($"{username} joins the {forceSide} side!");
    }
}

// print result
foreach (var side in forceSides.OrderByDescending(x => x.Value.Count).Where(x => x.Value.Count > 0))
{
    Console.WriteLine($"Side: {side.Key}, Members: {forceSides[side.Key].Count}");

    foreach (var user in side.Value)
    {
        Console.WriteLine($"! {user}");
    }
}
