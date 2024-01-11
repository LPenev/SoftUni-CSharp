//Lucas Jacob Noah Logan Ethan
//10

//Removed Ethan
//Removed Jacob
//Removed Noah
//Removed Lucas
//Last is Logan

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split();
            var queue = new Queue<string>(children);

            var counter = int.Parse(Console.ReadLine());

            for(int i = 1; i < children.Length; i++)
            {
                for(int j = 1; j <= counter; j++)
                {
                    if(j == counter)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                    else
                    {
                        queue.Enqueue(queue.Dequeue());
                    }
                }
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
