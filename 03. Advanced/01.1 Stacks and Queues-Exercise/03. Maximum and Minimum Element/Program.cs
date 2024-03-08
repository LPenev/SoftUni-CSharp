namespace _13._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            while (counter > 0)
            {
                int[] commandArray = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = commandArray[0];
                switch (command)
                {
                    // push element to stack
                    case 1:
                        int elementToPush = commandArray[1];
                        stack.Push(elementToPush);
                        break;

                    // pop element from stack
                    case 2:
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;

                    // print bigest element
                    case 3:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;

                    // print smallest element
                    case 4:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }

                counter--;
            }
            // print all elements from stack
            if (stack.Any())
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
