namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new(input);
                boxes.Add(box);
            }

            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
