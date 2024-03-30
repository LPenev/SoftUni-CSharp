int numberLines = int.Parse(Console.ReadLine());

string[] resultA = new string[numberLines];
string[] resultB = new string[numberLines];

for (int i = 0; i < numberLines; i++)
{
    var input = Console.ReadLine().Split();
    if(i%2 == 0)
    {
        resultA[i]= input[0];
        resultB[i] = input[1];
    }
    else
    {
        resultA[i] = input[1];
        resultB[i] = input[0];
    }
}

Console.WriteLine(string.Join(" ", resultA));
Console.WriteLine(string.Join(" ", resultB));