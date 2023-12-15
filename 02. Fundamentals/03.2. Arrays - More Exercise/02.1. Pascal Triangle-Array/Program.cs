int triangleLines = int.Parse(Console.ReadLine());

long[][] triangle = new long[triangleLines][];

for (int row = 0; row < triangleLines; row++)
{
    triangle[row] = new long[row + 1];
    triangle[row][0] = 1;
    triangle[row][^1] = 1;

    for (int column = 1; column < row; column++)
    {
        triangle[row][column] = triangle[row - 1][column - 1] + triangle[row - 1][column];
    }
}

for (var row = 0; row < triangleLines; row++)
{
    Console.WriteLine(string.Join(" ", triangle[row]));
}
