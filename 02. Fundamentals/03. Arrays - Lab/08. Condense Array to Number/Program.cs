﻿// read array from console
int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

// calculations
for (int i = 0; i < numbers.Length - 1; i++)
{
	for (int j = 0; j < numbers.Length - 1 - i; j++)
	{
		numbers[j] = numbers[j] + numbers[j + 1];
	}
}

// print result
Console.WriteLine(numbers[0]);