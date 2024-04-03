namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operationSing = Console.ReadLine();
            int operatorA = int.Parse(Console.ReadLine());
            int operatorB = int.Parse(Console.ReadLine());
            int result = 0;
            switch (operationSing)
            {
                case "add":
                    result = add(operatorA,operatorB);
                    break;
                case "multiply":
                    result = multiply(operatorA,operatorB);
                    break;
                case "subtract":
                    result = subtract(operatorA,operatorB);
                    break;
                case "divide":
                    result = divide(operatorA,operatorB);
                    break;
            }
            Console.WriteLine(result);
        }

        static int add(int a, int b)
        {
            int result = a + b;
            return result;
        }

        static int multiply(int a, int b)
        {
            int result = a * b;
            return result;
        }

        static int subtract(int a, int b)
        {
            int result = a - b;
            return result;
        }

        static int divide(int a, int b)
        {
            int result = a / b;
            return result;
        }
    }
}