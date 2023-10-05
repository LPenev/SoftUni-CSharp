namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseDigit = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double result = mathPower( baseDigit, power);
            Console.WriteLine(result);
        }

        static double mathPower(double baseDigit, double power)
        {
            double result = Math.Pow(baseDigit, power);
            return result;
        }
    }
}