namespace _12._Basic_Queue_Operations
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

            // Add elements to Queue
            int elemetsAddToStack = commandArray[0];
            Queue<int> queue = new(inputArray.Take(elemetsAddToStack));

            // Pop elements from Queue
            int elemetsDequeueFromQueue = commandArray[1];
            while (queue.Any() && elemetsDequeueFromQueue > 0)
            {
                queue.Dequeue();
                elemetsDequeueFromQueue--;
            }

            // Check for element in Queue - if exist print true
            int checkForElementInStack = commandArray[2];
            if (queue.Contains(checkForElementInStack))
            {
                Console.WriteLine("true");
            }
            // or print smallest element
            else if (queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            // if stack is empty print 0
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
