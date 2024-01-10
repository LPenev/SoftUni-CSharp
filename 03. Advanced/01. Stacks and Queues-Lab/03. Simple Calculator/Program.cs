using System.ComponentModel.DataAnnotations;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine()
                .Split()
                .ToArray();

            var stack = new Stack<string>(inputArray.Reverse());
            var result = int.Parse(stack.Pop());

            while (stack.Any())
            {
                var sign = stack.Pop();
                switch (sign)
                {
                    case "+":
                        result += int.Parse(stack.Pop());
                        break;
                    case "-":
                        result -= int.Parse(stack.Pop());
                        break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
