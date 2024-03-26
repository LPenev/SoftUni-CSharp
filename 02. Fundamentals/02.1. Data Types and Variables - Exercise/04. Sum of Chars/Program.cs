int numberOfCahrs = int.Parse(Console.ReadLine());

int sumOfChars = 0;
for (int i = 0; i < numberOfCahrs; i++)
{
    char input = char.Parse(Console.ReadLine());
    sumOfChars += input;
}
Console.WriteLine($"The sum equals: {sumOfChars}");