namespace _16.__Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songsArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songList = new Queue<string>(songsArray);

            while (true)
            {
                string input = Console.ReadLine();

                if (input.StartsWith("Play"))
                {
                    songList.Dequeue();

                    if (!songList.Any())
                    {
                        Console.WriteLine("No more songs!");
                        break;
                    }
                    
                }
                else if (input.StartsWith("Add"))
                {
                    string songName = input.Remove(0,4);
                    if(songList.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                        continue;
                    }
                    songList.Enqueue(songName);
                }
                else if(input.StartsWith("Show"))
                {
                    Console.WriteLine(string.Join(", ",songList));
                }
            }
        }
    }
}
