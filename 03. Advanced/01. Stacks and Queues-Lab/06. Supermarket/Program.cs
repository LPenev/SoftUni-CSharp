namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();

            var input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                if(input == "Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{queue.Count()} people remaining.");
        }
    }
}
