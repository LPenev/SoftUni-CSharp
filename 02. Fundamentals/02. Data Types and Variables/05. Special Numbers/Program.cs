// A number is special when its sum of digits is 5, 7 or 11.

int loops = int.Parse(Console.ReadLine());

for(int i = 1; i <= loops; i++)
{
    int current = i;
    int sum = default(int);

    while (current >= 1)
    {
        sum += current%10;
        current /= 10;
    }

    if(sum == 5 || sum == 7 || sum == 11)
    {
        Console.WriteLine($"{i} -> True");
    }
    else
    {
        Console.WriteLine($"{i} -> False");
    }
}