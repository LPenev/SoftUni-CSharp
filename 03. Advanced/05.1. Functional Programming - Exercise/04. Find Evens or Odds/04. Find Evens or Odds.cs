string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int rangeMin = int.Parse(input[0]);
int rangeMax = int.Parse(input[1]);
string condition = Console.ReadLine();

Func<int, bool> filter = CreateFilter(condition);

PrintRage(GenerateRange(rangeMin, rangeMax), filter);

void PrintRage(int[] digitsArray, Func<int, bool> filter)
{
    Console.WriteLine(String.Join(" ", digitsArray.Where(filter)));
}

int[] GenerateRange(int rangeMin, int rangeMax)
{
    int[] range = Enumerable.Range(rangeMin, rangeMax - rangeMin + 1).ToArray();

    return range;
}

Func<int, bool> CreateFilter(string condition)
{
    Func<int, bool> filter = null;

    if(condition == "odd")
    {
        filter = number => (number %2 != 0);
    }
    else if(condition == "even")
    {
        filter = number => (number %2 == 0);
    }

    return filter;
}