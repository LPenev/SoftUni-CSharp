namespace _107._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|")
                .ToList();
            
            List<int> result = new List<int>();

            input.Reverse();

            foreach (string current in input)
            {
                int[] currentTail = current.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                foreach (int tail in currentTail)
                {
                    result.Add(tail);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}