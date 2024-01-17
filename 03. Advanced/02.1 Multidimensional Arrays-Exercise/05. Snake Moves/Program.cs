int[] sizeArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = sizeArray[0];
int cols = sizeArray[1];
Char[,] matrix = new Char[rows, cols];

string inputedString = Console.ReadLine();
int currentStringPosition = 0;

for ( int row = 0; row < rows; row++)
{
    if(IsEven(row))
    {
        for( int col = 0; col < matrix.GetLength(1); col++)
        {
            if (IsStringPositionOver( inputedString,currentStringPosition))
            {
                currentStringPosition = 0;
            }
            matrix[row, col] = inputedString[currentStringPosition++];
        }
    }
    else
    {
        for( int col = matrix.GetLength(1) - 1; 0 <= col; col--)
        {
            if (IsStringPositionOver(inputedString, currentStringPosition))
            {
                currentStringPosition = 0;
            }
            matrix[row, col] = inputedString[currentStringPosition++];
        }
    }
    
}

PrintMatrix(matrix);

static void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}

bool IsEven(int row)
{
    return (row % 2 == 0);
}

bool IsStringPositionOver(string currentString, int currentPosition)
{
    return (currentStringPosition == inputedString.Length);
}