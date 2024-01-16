// read matrix size
int[] sizeArray = Console.ReadLine()
    .Split(",",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizeArray[0];
int columns = sizeArray[1];
int[,] matrix = new int[rows, columns];

// read from cosole and store to matrix
char separator = ',';
ConsoleToMatrix(matrix, separator);

// search for biggest sum of submatrix
SearchForBiggestSubmatrix(matrix);

// search for biggest sum of submatrix 2x2 
static void SearchForBiggestSubmatrix(int[,] matrix)
{
    int biggestSquareSum = 0;
    int bestRow = 0;
    int bestColumn = 0;

    for(int row = 0; row < matrix.GetLength(0) - 1; row++)
    {
        for(int column = 0;  column < matrix.GetLength(1) - 1; column++)
        {
            int currentSquareSum = matrix[row, column]
                + matrix[row, column + 1]
                + matrix[row + 1, column]
                + matrix[row + 1, column + 1];

            if(currentSquareSum > biggestSquareSum)
            {
                biggestSquareSum = currentSquareSum;
                bestRow = row;
                bestColumn = column;
            }
        }
    }

    // print result
    Console.WriteLine($"{matrix[bestRow, bestColumn]} {matrix[bestRow, bestColumn + 1]}");
    Console.WriteLine($"{matrix[bestRow + 1, bestColumn]} {matrix[bestRow + 1, bestColumn + 1]}");
    Console.WriteLine(biggestSquareSum);
}

static int[,] ConsoleToMatrix(int[,] matrix, char separator)
{
    // count of rows
    for (int rows = 0; matrix.GetLength(0) > rows; rows++)
    {
        int[] currentInput = Console.ReadLine()
            .Split(separator, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        // count of columns
        for (int columns = 0; matrix.GetLength(1) > columns; columns++)
        {
            matrix[rows, columns] = currentInput[columns];
        }
    }
    return matrix;
}
