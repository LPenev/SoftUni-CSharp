int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
int selectedNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < input.Length; i++)
{
	for (int j = i + 1; j < input.Length; j++)
	{
		if (selectedNumber == input[i] + input[j])
		{
			Console.WriteLine($"{input[i]} {input[j]}");
        }
	}
}
