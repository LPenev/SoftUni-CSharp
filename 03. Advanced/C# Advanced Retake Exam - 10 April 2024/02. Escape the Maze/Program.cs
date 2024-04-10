
int maxHealt = 100;
int health = 100;
int monsterDamage = 40;
int boostHealth = 15;

int squareMatrixSize = int.Parse(Console.ReadLine());
char[,] matrix = new char[squareMatrixSize, squareMatrixSize];

for (int row = 0; row < squareMatrixSize; row++)
{
    string input = Console.ReadLine();


    for (int col = 0; col < input.Length; col++)
    {
        matrix[row, col] = input[col];
    }
}

int currentRow = 0;
int currentCol = 0;

// search for jet
for (int row = 0; row < squareMatrixSize; row++)
{
    for (int col = 0; col < squareMatrixSize; col++)
    {
        if (matrix[row, col] == 'P')
        {
            currentRow = row;
            currentCol = col;
        }
    }
}

int newRow = 0;
int newCol = 0;
bool isNotOver = true;

while (isNotOver)
{
    string input = Console.ReadLine();
    if (input == "down")
    {
        newRow = currentRow + 1;
        newCol = currentCol;
    }
    else if (input == "up")
    {
        newRow = currentRow - 1;
        newCol = currentCol;
    }
    else if (input == "left")
    {
        newRow = currentRow;
        newCol = currentCol - 1;
    }
    else if (input == "right")
    {
        newRow = currentRow;
        newCol = currentCol + 1;
    }

    if (newRow < 0) newRow = 0;
    if (newCol < 0) newCol = 0;
    if (newRow == squareMatrixSize) newRow = squareMatrixSize - 1;
    if (newCol == squareMatrixSize) newCol = squareMatrixSize - 1;

    if (matrix[newRow, newCol] == 'M')
    {
        health -= monsterDamage;
        if (health <= 0)
        {
            Console.WriteLine("Player is dead. Maze over!");
            health = 0;
            isNotOver = false;
        }
    }
    else if (matrix[newRow, newCol] == 'H')
    {
        health += boostHealth;
        if (health > 100) health = 100;
    }
    else if (matrix[newRow, newCol] == 'X')
    {
        Console.WriteLine("Player escaped the maze. Danger passed!");
        isNotOver = false;
    }


    matrix[currentRow, currentCol] = '-';
    matrix[newRow, newCol] = 'P';
    currentRow = newRow;
    currentCol = newCol;

}

Console.WriteLine($"Player's health: {health} units");
// print matrix
for (int row = 0; row < squareMatrixSize; row++)
{
    for (int col = 0; col < squareMatrixSize; col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}
