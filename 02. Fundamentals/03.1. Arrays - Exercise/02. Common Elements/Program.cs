string[] inputA = Console.ReadLine().Split();
string[] inputB = Console.ReadLine().Split();

for (int i = 0; i < inputB.Length; i++)
{
    for (int j = 0; j < inputA.Length; j++)
    {
        if (inputB[i] == inputA[j])
        {
            Console.Write(inputB[i]);
            if(inputB.Length -1 != i)
            {
                Console.Write(" ");
            }
        }
    }
}
