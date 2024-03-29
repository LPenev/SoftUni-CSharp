int triangleLines = int.Parse(Console.ReadLine());
int current = 0;

for (int row = 0; row < triangleLines; row++)
{
	for (int column = 0; column <= row; column++)
	{
        if(column == 0)
        {
            current = 1;
        }
        else
        {
            current = current * (row - column + 1) / column;
            Console.WriteLine($"{current} = {current} * ({row} - {column} + 1) / {column}");
        }
        Console.Write(current + " ");
    }
    Console.WriteLine("new");
}
