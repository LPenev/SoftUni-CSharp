int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

int currentCounter = 0;
int currentNumber = 0;
int maxIndex = 0;
int maxLength = 0;

for (int i = 0; i < input.Length -1; i++)
{
    if (input[i] == input[i + 1])
    {
        currentNumber = input[i];
        currentCounter++;
        
        if (currentCounter > maxLength)
        {
            maxIndex = i;
            maxLength = currentCounter;
        }
    }
    else
    {
        currentNumber = 0;
        currentCounter = 0;
    }
}

for(int i = 0;i <= maxLength; i++)
{
    Console.Write($"{input[maxIndex]} ");
}