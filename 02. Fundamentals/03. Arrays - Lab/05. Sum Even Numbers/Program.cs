int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int sum = default;

foreach (var number in numbers)
{
    if (number%2 == 0) { sum += number; }
}

Console.WriteLine(sum);

