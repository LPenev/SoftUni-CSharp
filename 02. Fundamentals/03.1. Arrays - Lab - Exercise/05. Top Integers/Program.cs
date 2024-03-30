internal class Program
{
    private static void Main(string[] args)
    {
        // read from console
        int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < inputNumbers.Length; i++)
        {
           bool isTop = true;

            for (int j = i +1 ;inputNumbers.Length > j; j++)
            {
                if (inputNumbers[i] <= inputNumbers[j])
                {
                    isTop = false;
                    break;
                }
            }
            if (isTop) 
            {
                Console.Write(inputNumbers[i]);
                
                if(i < inputNumbers.Length - 1)
                {
                    Console.Write(" ");
                }
            }

        }
    }
}