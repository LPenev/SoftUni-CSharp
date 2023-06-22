namespace _06._OperationsBetween
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string oper = Console.ReadLine();

            // init variables
            double result = 0;
            string result2 = "";

            // calc
            if (n2 == 0)
            {

            }
            else if (oper == "+")
            {
                result = n1 + n2;
            }
            else if (oper == "-")
            {
                result = n1 - n2;
            }
            else if (oper == "*")
            {
                result = n1 * n2;
            }
            else if (oper == "/")
            {
                result = n1 / n2;
            }
            else if (oper == "%")
            {
                result = n1 % n2;
            }

            if (n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else if (oper != "%" && oper != "/")
            {
                if (result % 2 == 0)
                {
                    result2 = "even";
                }
                else
                {
                    result2 = "odd";
                }
                Console.WriteLine($"{n1} {oper} {n2} = {result} - {result2}");
            }
            else if (oper == "/" && n2 != 0)
            {
                Console.WriteLine($"{n1} {oper} {n2} = {result:f2}");
            }
            else if (oper == "%" && n2 != 0)
            {
                Console.WriteLine($"{n1} {oper} {n2} = {result}");
            }
        }
    }
}
