int input = int.Parse(Console.ReadLine());

int a = 1;
int b = 1;
int c = 1;

int counter = 2;
while (counter < input)
{
    // 1 1 2 3 5 8 13 21
    c = a + b;
    a = b;
    b = c;
    counter++;
}
Console.WriteLine(c);
