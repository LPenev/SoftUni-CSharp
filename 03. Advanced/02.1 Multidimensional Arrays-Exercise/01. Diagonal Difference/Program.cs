int sizeOfSquare = int.Parse(Console.ReadLine());

Console.WriteLine(DifferenceBetweenDiagonalSums(BuildSquare(sizeOfSquare)));

static int DifferenceBetweenDiagonalSums(int[,] square)
{
    int firstSum = 0;
    int secoundSum = 0;
    int secoundCounter = square.GetLength(0) - 1;

    for (int firstCounter = 0; firstCounter < square.GetLength(0); firstCounter++)
    {
        firstSum += square[firstCounter,firstCounter];
        secoundSum += square[firstCounter,secoundCounter];
        secoundCounter--;
    }

    int sum = Math.Abs(firstSum - secoundSum);
    return sum;
}

// Build square
static int[,] BuildSquare(int sizeOfSquare)
{
    int[,] square = new int[sizeOfSquare, sizeOfSquare];
    for (int row = 0; row < sizeOfSquare; row++)
    {
        int[] currentRow = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int column = 0; column < currentRow.Length; column++)
        {
            square[row, column] = currentRow[column];
        }
    }
    return square;
}