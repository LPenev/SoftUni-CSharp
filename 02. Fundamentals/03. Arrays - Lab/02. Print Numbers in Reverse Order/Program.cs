int lines = int.Parse(Console.ReadLine());

int[] numbers = new int[lines];

for(int i = 0; i < lines; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
}

for(int j = numbers.Length - 1; j >0; j--)
{
    Console.Write(numbers[j] + " ");
}

Console.Write(numbers[0]);
