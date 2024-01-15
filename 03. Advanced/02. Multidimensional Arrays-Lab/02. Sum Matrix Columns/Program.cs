int[] sizeArray = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizeArray[0];
int columns = sizeArray[1];
int[,] matrix = new int[rows, columns];

// read matrix from console
ConsoleToMatrix(matrix);

// print sum of columns by matrix
PrintSumOfRowsByMatrix(matrix);

// read from Console and store into matrix
static int[,] ConsoleToMatrix(int[,] matrix)
{
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        int[] inputArray = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        for(int columns = 0; columns < matrix.GetLength(1); columns++)
        {
            matrix[rows,columns] = inputArray[columns];
        }
    }
    return matrix;
}

// Print sum of columns by matrix
static void PrintSumOfRowsByMatrix(int[,] matrix)
{
    for(int columns = 0;columns < matrix.GetLength(1); columns++)
    {
        int sumOfColumns = 0;

        for(int rows = 0;rows < matrix.GetLength(0); rows++)
        {
            sumOfColumns += matrix[rows,columns];
        }

        Console.WriteLine(sumOfColumns);
    }
}
