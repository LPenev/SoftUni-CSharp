namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            input = Math.Abs(input);
            int sumOdd = GetSumOfOddDigits(input);
            int sumEven = GetSumOfEvenDigits(input);
            int sumOddAndEven = GetMultipleOfEvenAndOdds( sumOdd, sumEven);
            Console.WriteLine(sumOddAndEven);
        }

        static int GetMultipleOfEvenAndOdds(int sumOdds, int sumEven)
        {
            int sum = sumOdds * sumEven;
            return sum;
        }

        static int GetSumOfEvenDigits(int input)
        {
            int sumEven = 0;
            
            while (input > 0)
            {
                int currentDigit = input % 10;
                if (currentDigit % 2 == 0)
                {
                    sumEven += currentDigit;
                }
                input /= 10;
            }

            return sumEven;
        }

        static int GetSumOfOddDigits(int input)
        {
            int OddsSum = 0;
            while(input > 0)
            {
                int currentDigit = input % 10;
                if(currentDigit % 2 != 0)
                { 
                    OddsSum += currentDigit;
                }
                input /= 10;
            }
            return OddsSum;
        }
    }
}