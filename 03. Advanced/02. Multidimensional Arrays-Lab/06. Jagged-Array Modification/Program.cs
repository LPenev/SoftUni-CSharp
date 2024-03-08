// read count of rows
int countRows = int.Parse(Console.ReadLine());

// create row array
int[][] jagged = new int[countRows][];

// create columns and fill them
for (int i = 0; i < countRows; i++)
{
    jagged[i] = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();
}

string input = string.Empty;
while((input = Console.ReadLine()) != "END")
{
    string[] inputArray = input.Split();
    string command = inputArray[0];
    int row = int.Parse(inputArray[1]);
    int column = int.Parse(inputArray[2]);
    int currentValue = int.Parse(inputArray[3]);

    if (command == "Add")
    {
        if(IsValidJaggedCordinate(jagged, row, column))
        {
            int value = jagged[row][column] + currentValue;
            jagged[row][column] = value;
            continue;
        }
    }
    else if (command == "Subtract")
    {
        if (IsValidJaggedCordinate(jagged, row, column))
        {
            int value = jagged[row][column] - currentValue;
            jagged[row][column] = value;
            continue;
        }
    }

    Console.WriteLine("Invalid coordinates");
}

// print jagged matrix
PrintJagged(jagged);

// check is cordinate valid - method
static bool IsValidJaggedCordinate(int[][] jagged, int row, int column)
{
    if ( row >= 0 && column >= 0 &&
        row <= jagged.Length - 1 && 
        column <= jagged[row].Length - 1
        )
    {
        return true;
    }
    return false;
}

// print jagged matrix - method
static void PrintJagged(int[][] jagged)
{
    foreach (int[] jaggedRow in jagged)
    {
        Console.WriteLine(string.Join(" ", jaggedRow));
    }
}