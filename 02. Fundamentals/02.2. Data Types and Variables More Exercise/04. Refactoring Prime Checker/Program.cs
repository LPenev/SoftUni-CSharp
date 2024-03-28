int input = int.Parse(Console.ReadLine());

for (int i = 2; i <= input; i++)
{
    bool isPrime = true;
    for (int j = 2; j < i; j++)
    {
        if (i % j == 0)
        {
            isPrime = false;
            break;
        }
    }
    // print result
    Console.WriteLine("{0} -> {1}", i, isPrime.ToString().ToLower());
}
