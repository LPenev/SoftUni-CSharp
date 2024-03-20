int count = int.Parse(Console.ReadLine());

decimal sum = default(decimal);
for (int i = 0; i < count; i++)
{
    sum += decimal.Parse(Console.ReadLine()); 
}
Console.WriteLine(sum);