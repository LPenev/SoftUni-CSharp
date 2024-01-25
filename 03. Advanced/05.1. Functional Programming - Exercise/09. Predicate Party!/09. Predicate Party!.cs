List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

Controler(names);
PrintResult(names);

void Controler(List<string> names)
{
    string[] command = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (command[0] == "Party!")
    {
        return;
    }

    Func<string, bool> nameFunction = name =>
    {
        if (command[1] == "StartsWith")
        {
            return name.StartsWith(command[2]);
        }
        else if (command[1] == "EndsWith")
        {
            return name.EndsWith(command[2]);
        }
        else if (command[1] == "Length")
        {
            return int.Parse(command[2]) == name.Length;
        }
        return false;
    };

    switch (command[0])
    {
        case "Remove":
            for (int i = 0; i < names.Count; i++)
            {
                if (nameFunction(names[i]))
                {
                    names.RemoveAt(i);
                    --i;
                }
            }
            break;

        case "Double":
            for (int i = 0; i < names.Count; i++)
            {
                if (nameFunction(names[i]))
                {
                    names.Insert(i, names[i]);
                    ++i;
                }
            }
            break;
    }

    Controler(names);
}

void PrintResult(List<string> names)
{
    if (names.Count == 0)
    {
        Console.Write("Nobody is going to the party!");
    }
    else
    {
        Console.Write(String.Join(", ", names).TrimEnd());
        Console.WriteLine(" are going to the party!");
    }
}
