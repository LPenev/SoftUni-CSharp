List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

Dictionary<string, Predicate<string>> filters = new();

Logic(names, filters);
List<string> filtredNames = UpdateNames(names, filters);
PrintResult(filtredNames);

void Logic(List<string> names, Dictionary<string, Predicate<string>> filters)
{
    string[] inputArray = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
    string action = inputArray[0];

    if (action == "Print") return;

    string filter = inputArray[1];
    string value = inputArray[2];

    if(action == "Add filter")
    {
        filters.Add(filter + value, GetPredicate(filter, value));
    }
    else if(action == "Remove filter")
    {
        filters.Remove(filter+value);
    }

    Logic(names, filters);
}

List<string> UpdateNames(List<string> names, Dictionary<string, Predicate<string>> filters)
{
    foreach(var filter in filters)
    {
        names.RemoveAll(filter.Value);
    }
    return names;
}

Predicate<string> GetPredicate(string filter, string value)
{
    switch (filter)
    {
        case "Starts with":
            return x => x.StartsWith(value);

        case "Ends with":
            return x => x.EndsWith(value);

        case "Contains":
            return x => x.Contains(value);

        case "Length":
            return x=> x.Length == int.Parse(value);
    }
    return default;
}

void PrintResult(List<string> filtredNames)
{
    Console.WriteLine(String.Join(" ", names));
}