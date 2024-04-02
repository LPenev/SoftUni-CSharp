int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int foldPoint = input.Length / 4;
int[] result  = new int[foldPoint * 2];

for (int i = 0; i < foldPoint; i++)
{
    result[i] = input[i + foldPoint] + input[foldPoint - 1 - i];
    result[i + foldPoint] = input[i + 2 * foldPoint] + input[input.Length -1 -i];
}

Console.WriteLine(String.Join(' ', result));