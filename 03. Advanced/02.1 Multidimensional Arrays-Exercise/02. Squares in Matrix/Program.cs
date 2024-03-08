int searchSquareSize = 2;

int[] sizeOfMatrix = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizeOfMatrix[0];
int cols = sizeOfMatrix[1];

Console.WriteLine( SearchForSquares( ReadMatrixFromConsole(rows, cols), searchSquareSize));

static int SearchForSquares(string[,] matrix, int searchSquareSize)
{
    int squareCounter = 0;

    for (int row = 1; row < matrix.GetLength(0); row++)
    {
        for (int col = 1; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == matrix[row, col - 1] && 
                matrix[row, col] == matrix[row - 1, col - 1] &&
                matrix[row, col] == matrix[row - 1, col]
                )
            {
                squareCounter++;
            }
        }
    }
    return squareCounter;
}

// Read matrix from Console
static string[,] ReadMatrixFromConsole(int rows, int cols)
{
    string[,] matrix = new string[rows, cols];

    for (int row = 0; row < rows; row++)
    {
        string[] current = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = current[col];
        }
    }
    return matrix;
}