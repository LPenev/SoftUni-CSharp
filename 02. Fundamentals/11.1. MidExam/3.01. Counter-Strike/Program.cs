namespace _3._01._Counter_Strike
{
    internal class Program
    {
        static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int count = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End of battle")
                {
                    Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
                    break;
                }

                int distance = int.Parse(input);
                if (energy == 0 || energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
                    break;
                }
                energy -= distance;
                count++;

                if(count % 3 == 0)
                {
                    energy += count;
                }
            }
        }
    }
}