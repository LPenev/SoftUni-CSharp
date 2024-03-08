// read from console size of matrix, row and columns is always equal
int matrixSize = int.Parse(Console.ReadLine());

// create a matrix
char[,] matrix = new char[matrixSize, matrixSize];

// read from cosole and store to matrix
ConsoleToMatrix(matrix);

// read char to search
char charToSearch = char.Parse(Console.ReadLine());

// search char into matrix
SearchCharInMatrix(matrix, charToSearch);

// search char into matrix und print them
static void SearchCharInMatrix(char[,] matrix, char charToSearch)
{
    // read rows
    for(int row = 0; row < matrix.GetLength(0); row++)
    {
        // read columns
        for(int column = 0;  column < matrix.GetLength(1); column++)
        {
            char currentMatrixChar = matrix[row, column];
            if(currentMatrixChar == charToSearch)
            {
                // if found print current position and exit
                Console.WriteLine($"({row}, {column})");
                return;
            }
        }
    }
    // print massage, if not found
    Console.WriteLine($"{charToSearch} does not occur in the matrix");
}

// read from cosole and store to matrix
static char[,] ConsoleToMatrix(char[,] matrix)
{
    // count of rows
    for (int rows = 0; matrix.GetLength(0) > rows; rows++)
    {
        char[] currentInput = Console.ReadLine()
            .ToCharArray();

        // count of columns
        for (int columns = 0; matrix.GetLength(1) > columns; columns++)
        {
            matrix[rows, columns] = currentInput[columns];
        }
    }

    return matrix;
}
