namespace _3._03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (!input.StartsWith("End"))
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int index = int.Parse(command[1]);
                switch (command[0])
                {
                    case "Shoot":
                        int power = int.Parse(command[2]);

                        if (index >= 0 && index < targets.Count)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;

                    case "Add":
                        int value = int.Parse(command[2]);

                        if (index >= 0 && index < targets.Count)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;

                    case "Strike":
                        int radius = int.Parse(command[2]);
                        int startIndex = index - radius;
                        int endIndex = index + radius;

                        if (startIndex >= 0 && endIndex < targets.Count - 1)
                        {
                            targets.RemoveRange(startIndex, endIndex - startIndex + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}