// read from conosle size of board
int boardSize = int.Parse(Console.ReadLine());
char[,] boardMatrix = new char[boardSize, boardSize];

// read from console and fillup board
for(int row = 0; row < boardSize; row++)
{
    char[] currentRow = Console.ReadLine().Trim().ToCharArray();
    for(int col = 0; col < currentRow.Length; col++)
    {
        boardMatrix[row, col] = currentRow[col];
    }
}

// check board size
if (boardSize < 3)
{
    Console.WriteLine(0);
    return;
}

// check for Knights
int mostKnightAttacks = 0;
int removedKnights = 0;
do
{
    // set default values for loop
    mostKnightAttacks = 0;
    int mostKnightAttacksRow = 0;
    int mostKnightAttacksCol = 0;

    for (int row = 0;row < boardSize; row++)
    {
        for(int col = 0;col < boardSize; col++)
        {
            int currentKnightAttacks = 0;

            currentKnightAttacks = NumberAttacksFromCurrentPosition(row, col, boardMatrix);

            // check for most attacks
            if (currentKnightAttacks > mostKnightAttacks)
            {
                mostKnightAttacks = currentKnightAttacks;
                mostKnightAttacksRow = row;
                mostKnightAttacksCol = col;
            }
        }
    }

    if(mostKnightAttacks > 0)
    {
        boardMatrix[mostKnightAttacksRow, mostKnightAttacksCol] = '0';
        removedKnights++;
    }
}
while (mostKnightAttacks > 0);


// print result
Console.WriteLine(removedKnights);

static bool IsValidBoardPositionWithKnight(int row, int col, char[,] boardMatrix)
{
    if (row < 0 || col < 0 
        || row >= boardMatrix.GetLength(0) || col >= boardMatrix.GetLength(1) 
        || boardMatrix[row, col] != 'K' )
    {
        return false;
    }

    return true;
}

static int NumberAttacksFromCurrentPosition(int row, int col, char[,] boardMatrix)
{
    int currentKnightAttacks = 0;
    // check up-left
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row - 2, col - 1, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    // check up-rigth
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row - 2, col + 1, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    // check down-left
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row + 2, col - 1, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    // check down-rigth
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row + 2, col + 1, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    // check left-up
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row - 1, col - 2, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    // check left-down
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row + 1, col - 2, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    // check rigth-up
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row - 1, col + 2, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    // check rigth-down
    if (boardMatrix[row, col] == 'K')
    {
        if (IsValidBoardPositionWithKnight(row + 1, col + 2, boardMatrix))
        {
            currentKnightAttacks++;
        }
    }

    return currentKnightAttacks;
}