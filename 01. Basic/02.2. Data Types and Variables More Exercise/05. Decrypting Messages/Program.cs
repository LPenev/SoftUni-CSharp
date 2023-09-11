int key = int.Parse(Console.ReadLine());
int interval = int.Parse(Console.ReadLine());

for (int i = 0; i < interval; i++)
{
    char input = char.Parse(Console.ReadLine());
    Console.Write((char)(input+key));
}