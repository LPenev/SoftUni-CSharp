int inputNumberLines = int.Parse(Console.ReadLine());

for(int i = 0; i < inputNumberLines; i++)
{
    string input = Console.ReadLine();
    string[] output = input.Split(' ');

    long left = long.Parse(output[0]);
    long right = long.Parse(output[1]);
    long number;
    long sum = 0;

    if( left > right )
    {
        number = left;
    }
    else
    {
        number= right;
    }

    if( number < 0) { number *= -1; }
   
    while( number > 0)
    {
        sum += number % 10;
        number /= 10;
    }

    Console.WriteLine(sum);
}