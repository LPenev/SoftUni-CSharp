namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var evenArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x%2 == 0)
                .ToArray();

            var evenNumbers = new Queue<int>(evenArray);
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
