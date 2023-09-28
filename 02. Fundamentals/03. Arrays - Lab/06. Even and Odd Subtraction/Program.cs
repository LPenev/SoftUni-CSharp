int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int sumEven = default;
int sumOdd = default;

foreach (int number in numbers)
{
    if(number%2 == 0)
    {
        sumEven += number;
    }
    else
    {
        sumOdd += number;
    }
}
// print result
Console.WriteLine(sumEven - sumOdd);