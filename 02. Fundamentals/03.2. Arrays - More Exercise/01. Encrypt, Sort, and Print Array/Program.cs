int numberOfReads = int.Parse(Console.ReadLine());

int[] result = new int[numberOfReads];
int counter = 0;

while (numberOfReads > 0)
{
    numberOfReads--;

    string input = Console.ReadLine();
    char[] inputArray = input.ToCharArray();
    int sumOfChar = 0;

    foreach (char currentChar in inputArray)
    {
        switch(currentChar)
        {
            case 'a': case 'e': case 'i': case 'o': case 'u': case 'A': case 'E': case 'I': case 'O': case 'U':
                sumOfChar += (int)currentChar * inputArray.Length;
                break;
            default:
                sumOfChar += (int)currentChar / inputArray.Length;
                break;
        }
    }
    result[counter] = sumOfChar;
    counter++;
}
Array.Sort(result);
foreach (int i in result)
{
    Console.WriteLine(i);
}