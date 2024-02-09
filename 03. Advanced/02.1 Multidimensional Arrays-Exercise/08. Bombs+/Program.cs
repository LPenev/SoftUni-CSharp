// read square matrix size from console
using System.Data;

int squareMatrixSize = int.Parse(Console.ReadLine());

// make square matrix with int
int[,] squareMatrix = new int[squareMatrixSize, squareMatrixSize];

// fillup matrix from console
for (int row = 0; row < squareMatrixSize; row++)
{
    int[] currentRowInput = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < squareMatrixSize; col++)
    {
        squareMatrix[row, col] = currentRowInput[col];
    }
}

string[] bombArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int bombCount = 0; bombCount < bombArray.Length; bombCount++)
{
    int[] currentCoordinates = bombArray[bombCount].Split(",").Select(int.Parse).ToArray();
    int currentRow = currentCoordinates[0];
    int currentCol = currentCoordinates[1];

    if (IsBombCoordinatesValid(currentRow, currentCol, squareMatrix))
    {
        BombExlosion(currentRow, currentCol, squareMatrix);
    }
}

static void BombExlosion(int currentRow, int currentCol, int[,] squareMatrix)
{
    if (!IsBombCoordinatesValid(currentRow, currentCol, squareMatrix))
    {
        return;
    }

    int forceExplosion = squareMatrix[currentRow, currentCol];

    squareMatrix[currentRow, currentCol] = 0;

    int bombRow = 0;
    int bombCol = 0;

    // explosion up-left
    bombRow = currentRow - 1;
    bombCol = currentCol - 1;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }

    // explosion up
    bombRow = currentRow - 1;
    bombCol = currentCol;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }

    // explosion up-rigth
    bombRow = currentRow - 1;
    bombCol = currentCol + 1;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }

    // explosion left
    bombRow = currentRow;
    bombCol = currentCol - 1;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }

    // explosion rigth
    bombRow = currentRow;
    bombCol = currentCol + 1;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }

    // explosion down-left
    bombRow = currentRow + 1;
    bombCol = currentCol - 1;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }

    // explosion down
    bombRow = currentRow + 1;
    bombCol = currentCol;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }

    // explosion down-rigth
    bombRow = currentRow + 1;
    bombCol = currentCol + 1;

    if (IsBombCoordinatesValid(bombRow, bombCol, squareMatrix))
    {
        squareMatrix[bombRow, bombCol] -= forceExplosion;
    }
}

// print Alive Cells and Sum
int aliveCells = 0;
int sumOfAliveCells = 0;

for (int row = 0; row < squareMatrix.GetLength(0); row++)
{
    for (int col = 0; col < squareMatrix.GetLength(1); col++)
    {
        if (squareMatrix[row, col] > 0)
        {
            aliveCells++;
            sumOfAliveCells += squareMatrix[row, col];
        }
    }
}

Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {sumOfAliveCells}");

// print square matrix

for (int row = 0; row < squareMatrix.GetLength(0); row++)
{
    for (int col = 0; col < squareMatrix.GetLength(1); col++)
    {
        Console.Write($"{squareMatrix[row, col]} ");
    }
    Console.WriteLine();
}


static bool IsBombCoordinatesValid(int currentRow, int currentCol, int[,] squareMatrix)
{
    return currentRow >= 0 && currentRow < squareMatrix.GetLength(0)
        && currentCol >= 0 && currentCol < squareMatrix.GetLength(1)
        && squareMatrix[currentRow, currentCol] > 0;
}