int countOfNames = int.Parse(Console.ReadLine());

HashSet<string> names = new HashSet<string>();

// fill HashSet with unique names
for(int i = 0; i < countOfNames; i++)
{
    string name = Console.ReadLine();

    // check for name is in names exist.
    if (!names.Contains(name))
    {
        names.Add(name);
    }
}

// print names from HashSet
foreach (string name in names)
{
    Console.WriteLine(name);
}