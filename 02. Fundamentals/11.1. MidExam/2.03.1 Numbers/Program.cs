namespace _2._03._1_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double averageSum = numbers.Average();

            int[] result = numbers
                .OrderByDescending(x => x)
                .Where(x => x > averageSum)
                .Take(5)
                .ToArray();

            if (result.Length > 0)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}