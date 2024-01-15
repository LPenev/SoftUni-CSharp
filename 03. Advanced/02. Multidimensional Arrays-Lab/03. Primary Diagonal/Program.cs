// read from console size of matrix, row and columns is always equal
int matrixSize = int.Parse(Console.ReadLine());
// create a matrix
int[,] matrix = new int[matrixSize,matrixSize];

// read from cosole and store to matrix
ConsoleToMatrix(matrix);

// print sum of matrix diagonal
PrintSumOfMatrixDiagonal(matrix);

// print sum of matrix diagonal
static void PrintSumOfMatrixDiagonal(int[,] matrix)
{
    int sumOfDiagonal = 0;
    // by diagonal read of matrix, row und columns are always the same
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sumOfDiagonal += matrix[i,i];
    }
    // print result
    Console.WriteLine(sumOfDiagonal);
}

// read from cosole and store to matrix
static int[,] ConsoleToMatrix(int[,] matrix)
{
    // count of rows
    for (int rows = 0;matrix.GetLength(0) > rows; rows++)
    {
        int[] currentInput = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        // count of columns
        for(int columns = 0;matrix.GetLength(1)  > columns; columns++)
        {
            matrix[rows,columns] = currentInput[columns];
        }
    }

    return matrix;
}