int input = int.Parse(Console.ReadLine());

int[] fibonacci = new int[50];

fibonacci[0] = 1;
fibonacci[1] = 1;
int i = 2;

for(; i < input; i++)
{
    fibonacci[i] = fibonacci[i - 2] + fibonacci[i - 1];
}
Console.WriteLine(fibonacci[i - 1]);
