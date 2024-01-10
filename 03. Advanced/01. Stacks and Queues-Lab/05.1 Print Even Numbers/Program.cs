namespace _05._1_Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var evenArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var evenNumbers = new Queue<int>(evenArray);

        }
    }
}
