int[] array = { 1, 2, 3, 4 };

UpdateArray(ref array);

Console.WriteLine("[ {0} ]",string.Join(", ",array));

static void UpdateArray(ref int[] inputedArray )
{
    for(int i = 0; i < inputedArray.Length; i++)
    {
        inputedArray[i] = inputedArray[i] + 1;
    }
}