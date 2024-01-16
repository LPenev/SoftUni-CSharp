int height = int.Parse(Console.ReadLine());

long[][] triangle = BuildTriangle(height);
PrintTriangle(triangle);

// Build Triangle into jaggled-array
static long[][] BuildTriangle(int height)
{
    long[][] triangle = new long[height][];
    for (int row = 0; row < height; row++)
    {
        int currentWidth = row + 1;
        triangle[row] = new long[currentWidth];
        // fill first and last element of current row
        triangle[row][0] = 1;
        triangle[row][triangle[row].Length - 1] = 1;

        if (row > 1)
        {
            // fill current row
            for (int column = 1; column < triangle[row].Length - 1; column++)
            {
                long previousRowSum = triangle[row - 1][column - 1] + triangle[row - 1][column]; ;
                triangle[row][column] = previousRowSum;
            }
        }
    }
    return triangle;
}

// Print triangle
static void PrintTriangle(long[][] triangle)
{
    foreach (long[] rows in triangle)
    {
        Console.WriteLine(string.Join(" ", rows));
    }
}