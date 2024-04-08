namespace _1110._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsTopNumber(int currentNumber)
        {
            int[] current = currentNumber
                .ToString()
                .Select(x => x.ToString())
                .Select(int.Parse)
                .ToArray();

            bool isDivisibleByEight = IsDivisibleByEight(current);

            foreach (int i in current)
            {
                if(i%2 != 0 && isDivisibleByEight)
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsDivisibleByEight(int[] current)
        {
            if(current.Sum()%8 == 0)
            {
                return true;
            }
            return false;
        }
    }
}