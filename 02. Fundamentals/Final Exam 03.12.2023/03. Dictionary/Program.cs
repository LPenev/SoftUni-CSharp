namespace _03._Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var notebook = new Dictionary<string, List<string>>();

            var messege = Console.ReadLine().Split(" | ");
            foreach (var current in messege)
            {
                var currentArray = current.Split(": ");
                var word = currentArray[0];
                var definition = currentArray[1];

                if (notebook.ContainsKey(word))
                {
                    notebook[word].Add(definition);
                }
                else
                {
                    notebook.Add(word, new List<string>());
                    notebook[word].Add(definition);
                }
            }

            var keywords = Console.ReadLine().Split(" | ");
            var command = Console.ReadLine();

            if (command == "Test")
            {
                foreach (var current in keywords)
                {
                    if (notebook.ContainsKey(current))
                    {
                        Console.WriteLine($"{current}:");

                        foreach(var definition in notebook[current])
                        {
                            Console.WriteLine($"-{definition}");
                        }
                    }
                }
            }
            else if (command == "Hand Over")
            {
                Console.WriteLine(String.Join(" ", notebook.Keys));
            }
        }
    }
}
