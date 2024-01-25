Func<string, int[]> readIntegers = input => input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
.Select(int.Parse)
.ToArray();

int sizeOfRange = int.Parse(Console.ReadLine());
int[] dividers = readIntegers(Console.ReadLine());

Func<int, int, bool> isDivisible = (x,y)=> x % y == 0;

List<int> predicates = new List<int>();

CheckNumbersInRange(sizeOfRange, dividers);
PrintResult(predicates);

void CheckNumbersInRange(int sizeOfRange, int[] dividers)
{
    for(int i = 1; i <= sizeOfRange; i++)
    {
        bool isPredictates = true;

        for(int j = 0; j < dividers.Length; j++)
        {
            if (!isDivisible(i, dividers[j]))
            {
                isPredictates = false;
                break;
            }
        }

        if(isPredictates)
        {
            predicates.Add(i);
        }
    }
}

void PrintResult(List<int> predicates)
{
    Console.WriteLine(String.Join(" ", predicates));
}