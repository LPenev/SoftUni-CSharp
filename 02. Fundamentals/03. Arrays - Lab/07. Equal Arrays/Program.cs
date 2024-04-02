int[] numbersA = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] numbersB = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int sumNumbers = default;
bool isEqual = true;

for(int i = 0; i < numbersA.Length; i++)
{
    if (numbersA[i] == numbersB[i])
    {
        sumNumbers += numbersA[i];
    }
    else
    {
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        isEqual = false;
        break;
    }

}

if (isEqual)
{
    Console.WriteLine($"Arrays are identical. Sum: {sumNumbers}");
}