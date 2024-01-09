namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(inputArray);

            var input = string.Empty;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                var commandArray = input.Split(' ');
                var command = commandArray[0];
                var token1 = int.Parse(commandArray[1]);

                switch (command)
                {
                    case "add":
                        var token2 = int.Parse(commandArray[2]);
                        stack.Push(token1);
                        stack.Push(token2);
                        break;

                    case "remove":
                        int n = token1;
                        while (n > 0 && stack.Count() > n)
                        {
                            stack.Pop();
                            n--;
                        }
                        break;
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
