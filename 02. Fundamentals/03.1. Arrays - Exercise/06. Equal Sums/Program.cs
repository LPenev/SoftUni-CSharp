string input = Console.ReadLine();
if (input == "")
{
    Console.WriteLine("No such index exists");
}
else
{
    int[] numbers = input.Split().Select(int.Parse).ToArray();

    int sumLeft = 0;
    int sumRight = 0;
    int i = 0;
    bool isEqual = false;

    for (i = 0; i < numbers.Length; i++)
    {
        sumLeft = 0;
        sumRight = 0;

        for (int j = i - 1; j >= 0; j--)
        {
            sumLeft += numbers[j];
        }

        for (int k = i + 1; k < numbers.Length; k++)
        {
            sumRight += numbers[k];
        }

        if(sumLeft == sumRight)
        {
            isEqual = true;
            break;
        }

    }

    // print result
    if (isEqual)
    {
        Console.WriteLine(i);
    }
    else
    {
        Console.WriteLine("no");
    }
}