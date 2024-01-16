int[] sizeOfMatrix = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizeOfMatrix[0];
int cols = sizeOfMatrix[1];

SearchBiggestSumOfSquare( ReadMatrixFromConsole(rows, cols));

static int[,] ReadMatrixFromConsole(int rows, int cols)
{
    int[,] matrix = new int[rows, cols];

    for (int row = 0; row < rows; row++)
    {
        int[] current = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = current[col];
        }
    }
    return matrix;
}

static void SearchBiggestSumOfSquare(int[,] matrix)
{
    int bestSquareSum = int.MinValue;
    int bestSquareRow = 0, bestSquareColumn = 0;

    for (int row = 2; row < matrix.GetLength(0); row++)
    {
        for (int col = 2; col < matrix.GetLength(1); col++)
        {
            int currentSum = matrix[row, col] + matrix[row, col - 1] + matrix[row, col - 2]
                + matrix[row - 1, col] + matrix[row - 1, col - 1] + matrix[row - 1, col - 2]
                + matrix[row - 2, col] + matrix[row - 2, col - 1] + matrix[row - 2, col - 2];
                
            if( currentSum > bestSquareSum)
            {
                bestSquareSum = currentSum;
                bestSquareRow = row;
                bestSquareColumn = col;
            }
        }
    }

    Console.WriteLine($"Sum = {bestSquareSum}");

    for (int row = bestSquareRow - 2; row <= bestSquareRow; row++)
    {
        for (int col = bestSquareColumn - 2; col <= bestSquareColumn; col++)
        {
            Console.Write(matrix[row, col]);
            if (col < bestSquareColumn)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}