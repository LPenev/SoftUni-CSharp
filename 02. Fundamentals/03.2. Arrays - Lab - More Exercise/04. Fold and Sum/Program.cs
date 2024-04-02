int[] input = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int foldLenght = input.Length / 4;
int counter = foldLenght;

for (int i = foldLenght -1 ; i >= 0; i--)
{
    Console.Write(input[i] + input[counter] + " ");
    counter++;
}

for (int j = input.Length - 1 ; j > input.Length - foldLenght -1; j--)
{
    Console.Write(input[j] + input[counter] + " ");
    counter++;
}