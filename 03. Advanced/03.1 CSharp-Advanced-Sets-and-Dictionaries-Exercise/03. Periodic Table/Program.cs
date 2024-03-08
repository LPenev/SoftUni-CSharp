int countOfElements = int.Parse(Console.ReadLine());
SortedSet<string> sortedSetOfInt = new();

for (int i = 0; i < countOfElements; i++)
{
    string[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    
    sortedSetOfInt.UnionWith(inputArray);
}

Console.WriteLine(string.Join(" ", sortedSetOfInt));