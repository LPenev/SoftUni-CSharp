
// read matrix size
int[] tokens = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = tokens[0];
int columns = tokens[1];

// create matrix
int[,] matrix = new int[rows, columns];

// read from Console and store in matrix
for(int r = 0; r < rows; r++)
{
    int[] inputArray = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for(int c = 0; c < columns; c++)
    {
        matrix[r,c] = inputArray[c];
    }
}

// calc sum of matix
int sumOfMatrix = 0;
foreach(var row in matrix)
{
    sumOfMatrix += row;
}

// print rows and columns size
Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));

// print sum of matirx
Console.WriteLine(sumOfMatrix);