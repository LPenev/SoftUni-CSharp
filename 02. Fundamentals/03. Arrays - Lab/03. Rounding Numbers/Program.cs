string input = Console.ReadLine();

double[] numbers = input.Split().Select(double.Parse).ToArray();

for (int i = 0; i < numbers.Length; i++)
{

    double printNumber = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
    
    if(printNumber == 0) { printNumber = 0; }
    
    Console.WriteLine($"{numbers[i]} => {printNumber}");
}