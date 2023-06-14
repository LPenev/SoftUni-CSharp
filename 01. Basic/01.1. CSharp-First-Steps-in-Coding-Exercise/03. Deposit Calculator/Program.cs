namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            double depositSum = double.Parse(Console.ReadLine());
            int depositCount = int.Parse(Console.ReadLine());
            double yearInterest = double.Parse(Console.ReadLine());
            // Calc
            yearInterest = (depositSum * yearInterest / 100) / 12;
            depositSum = depositSum + yearInterest * depositCount;
            // Show result
            Console.WriteLine(depositSum);
        }
    }
}
