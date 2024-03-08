namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var inputItem = int.Parse(Console.ReadLine());
                items.Add(inputItem);
            }

            var index = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Box<int> box = new Box<int>(items, index[0], index[1]);
        }
    }
}
