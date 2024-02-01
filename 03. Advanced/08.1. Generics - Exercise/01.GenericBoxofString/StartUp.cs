namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new(input);
                boxes.Add(box);
            }

            foreach (Box<string> box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
