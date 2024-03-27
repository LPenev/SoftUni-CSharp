int number = int.Parse(Console.ReadLine());
int begin = 97;
number += begin;

for (int i = begin; i < number; i++)
{
    for (int j = begin; j < number; j++)
    {
        for (int k = begin; k < number; k++)
        {
            Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
        }
    }
}