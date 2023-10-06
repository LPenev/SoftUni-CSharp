namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double operatorA = double.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            double operatorB = double.Parse(Console.ReadLine());
            
            double result = Calculate(operatorA, @operator, operatorB);
            Console.WriteLine(result);
        }

        static double Calculate(double operA, string @operator, double operB)
        {
            double result = 0;
            switch (@operator)
            {
                case "*":
                    result = operA * operB;
                    break;
                case "/":
                    result = operA / operB;
                    break;
                case "+":
                    result = operA + operB;
                    break;
                case "-":
                    result = operA - operB;
                    break;
            }

            return result;
        }
    }
}