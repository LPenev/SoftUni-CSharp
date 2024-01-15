// read matrix size
int[] tokens = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = tokens[0];
int columns = tokens[1];

// create matrix
int[,] matrix = new int[rows, columns];

// read from console and store in matrix
ConsoleToMatrix(matrix);

// print rows and columns size
Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));

// print sum of matirx
Console.WriteLine(SumOfMatrix(matrix));

int[,] ConsoleToMatrix(int[,] matrix)
{
    // read from Console and store in matrix
    for (int rows = 0; rows < matrix.GetLength(0); rows++)
    {
        int[] inputArray = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int columns = 0; columns < matrix.GetLength(1); columns++)
        {
            matrix[rows, columns] = inputArray[columns];
        }
    }
    return matrix;
}

int SumOfMatrix(int[,] matrix)
{
    // calc sum of matix
    int sumOfMatrix = 0;
    foreach (var row in matrix)
    {
        sumOfMatrix += row;
    }
    return sumOfMatrix;
}