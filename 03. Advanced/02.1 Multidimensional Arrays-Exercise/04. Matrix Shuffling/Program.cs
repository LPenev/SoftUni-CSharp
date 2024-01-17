int[] sizeOfMatrix = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int matrixRows = sizeOfMatrix[0];
int matrixColumns = sizeOfMatrix[1];

string[,] matrix = ReadMatrixFromConsole(matrixRows, matrixColumns);

string input = string.Empty;
while((input = Console.ReadLine()) != "END")
{
    string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries); 
    string command = inputArray[0];
    if (command == "swap")
    {
        if (inputArray.Length != 5)
        {
            PrintErrorMessage();
            continue;
        }

        int row = int.Parse(inputArray[1]);
        int col = int.Parse(inputArray[2]);
        int toRow = int.Parse(inputArray[3]);
        int toCol = int.Parse(inputArray[4]);

        swapElements( row, col, toRow , toCol );
    }
    else
    {
        PrintErrorMessage();
    }
}

void swapElements( int row, int col, int toRow, int toCol)
{
    if (!IsMatrixSizeCorrect(row, col) && !IsMatrixSizeCorrect(toRow, toCol))
    {
        PrintErrorMessage();
        return;
    }
    string temp = matrix[row, col];
    matrix[row, col] = matrix[toRow, toCol];
    matrix[toRow, toCol] = temp;
    PrintMatrix(matrix);
}

bool IsMatrixSizeCorrect(int row, int col)
{
    if(row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1))
    {
        return true;
    }
    return false;
}
static void PrintMatrix(string[, ] matrix)
{
    for(int row = 0; row < matrix.GetLength(0); row++)
    {
        for(int col = 0;  col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}

static void PrintErrorMessage()
{
    Console.WriteLine("Invalid input!");
}

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
