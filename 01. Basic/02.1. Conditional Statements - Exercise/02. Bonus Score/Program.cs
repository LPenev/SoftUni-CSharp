namespace _02._Bonus_Score
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input bonus digit
            int digit = int.Parse(Console.ReadLine());
            double bonus = 0;
            // Calculate Bonus
            if (digit <= 100)
            {
                bonus = 5;
            }
            else if (digit < 1000)
            {
                bonus = digit * 0.2;
            }
            else
            {
                bonus = digit * 0.1;
            }
            // Calc extra bonus
            if (digit % 2 == 0)
            {
                bonus += 1;
            }
            else if (digit % 10 == 5)
            {
                bonus += 2;
            }

            // Print result
            Console.WriteLine(bonus);
            Console.WriteLine(digit + bonus);
        }
    }
}
