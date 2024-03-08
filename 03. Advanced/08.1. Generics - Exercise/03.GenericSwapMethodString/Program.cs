namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var inputItem = Console.ReadLine();
                items.Add(inputItem);
            }

            var index = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Box<string> box = new Box<string>(items, index[0], index[1]);
        }
    }
}
