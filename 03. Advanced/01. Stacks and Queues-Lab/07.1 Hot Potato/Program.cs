//Lucas Jacob Noah Logan Ethan
//10

//Removed Ethan
//Removed Jacob
//Removed Noah
//Removed Lucas
//Last is Logan

namespace _07._1_Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split();
            var queue = new Queue<string>(children);

            var counter = int.Parse(Console.ReadLine());

            while(queue.Count > 1)
            {
                for(int i = 1; i < counter; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}