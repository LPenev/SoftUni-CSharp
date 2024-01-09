namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<string>();
            
            foreach (var current in input)
            {
                stack.Push(current.ToString());
            }

            Console.WriteLine(string.Join("",stack));
        }
    }
}
