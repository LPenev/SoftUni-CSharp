namespace _1108._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputA = int.Parse(Console.ReadLine());
            int inputB = int.Parse(Console.ReadLine());
            double factorial = Factoriel(inputA);
            double devision = Factoriel(inputB);
            double result = factorial / devision;
            Console.WriteLine($"{result:F2}");
        }

        static double Factoriel(int input)
        {
            long factorial = 1;
            for (int i = input;i > 0;i--)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}