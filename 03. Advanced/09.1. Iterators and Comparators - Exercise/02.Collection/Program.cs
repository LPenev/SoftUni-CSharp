namespace _02.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();
            ListyIterator<string> list = new(words);


            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "PrintAll":
                        foreach (var current in list)
                        {
                            Console.Write(current + " ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
