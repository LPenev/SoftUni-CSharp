using System.Numerics;

int rowsOfMatirx = int.Parse(Console.ReadLine());

if (rowsOfMatirx < 2)
{
    return;
}

double[][] jagged = new double[rowsOfMatirx][];

// read jaged matrx from console
for (int row = 0; row < rowsOfMatirx; row++)
{
    double[] inputArray = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(double.Parse)
        .ToArray();
    jagged[row] = inputArray;
}

// Analyce
for (int row = 0; row < jagged.Length - 1; row++)
{
    if (jagged[row].Length == jagged[row + 1].Length)
    {
        jagged[row] = jagged[row].Select(x => x * 2).ToArray();
        jagged[row + 1] = jagged[row + 1].Select(x => x * 2).ToArray();
    }
    else
    {
        jagged[row] = jagged[row].Select(x => x / 2).ToArray();
        jagged[row + 1] = jagged[row + 1].Select(x => x / 2).ToArray();
    }
}

string input = string.Empty;
while ((input = Console.ReadLine()) != "End")
{
    string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = inputArray[0];
    int row = int.Parse(inputArray[1]);
    int col = int.Parse(inputArray[2]);
    double value = double.Parse(inputArray[3]);

    // check inputed row and column is in matrix range
    if (row < 0 || row >= jagged.Length || col < 0 || col >= jagged[row].Length)
    {
        continue;
    }

    if (command == "Add")
    {
        jagged[row][col] += value;

    }
    else if(command == "Subtract")
    {
        jagged[row][col] -= value;
    }
}

// print matrix
for (int row = 0; row < jagged.Length; row++)
{
    for (int col = 0; col < jagged[row].Length; col++)
    {
        Console.Write($"{jagged[row][col]} ");
    }
    Console.WriteLine();
}