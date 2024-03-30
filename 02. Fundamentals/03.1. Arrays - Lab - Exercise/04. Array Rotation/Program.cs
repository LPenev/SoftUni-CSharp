// read from console
int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
int countsOfRotations = int.Parse(Console.ReadLine());

// calculations
for (int i = 0; i < countsOfRotations; i++)
{
    int firstElement = numbers[0];
	for (int j = 0; j < numbers.Length -1; j++)
	{
		numbers[j] = numbers[j + 1];
	}
	numbers[numbers.Length-1] = firstElement;
}

// print result
Console.WriteLine(string.Join(" ", numbers));