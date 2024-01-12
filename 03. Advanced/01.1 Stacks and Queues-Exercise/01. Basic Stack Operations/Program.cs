namespace _11._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input commands
            int[] commandArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            // input array with numbers
            int[] inputArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            // Add elements to Stack
            int elemetsAddToStack = commandArray[0];
            Stack<int> stack = new Stack<int>(inputArray.Take(elemetsAddToStack));

            // Pop elements from Stack
            int elemetsPopFromStack = commandArray[1];
            while (stack.Any() && elemetsPopFromStack > 0)
            {
                stack.Pop();
                elemetsPopFromStack--;
            }

            // Check for element in Stack - if exist print true
            int checkForElementInStack = commandArray[2];
            if (stack.Contains(checkForElementInStack))
            {
                Console.WriteLine("true");
            }
            // or print smallest element
            else if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            // if stack is empty print 0
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
