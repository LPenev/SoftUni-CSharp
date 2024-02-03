namespace GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            string itemToCompare = Console.ReadLine();

            int countOfLarger = box.CompareToItem(itemToCompare);
            Console.WriteLine(countOfLarger);
        }
    }
}
