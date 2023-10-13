namespace _1011._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> trainWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());

            while (true)
            {
                string command = Console.ReadLine();

                if (command.StartsWith("Add"))
                {
                    string[] passengers = command.Split();
                    trainWagons.Add(int.Parse(passengers[1]));
                }
                else if (command.StartsWith("end"))
                {
                    Console.WriteLine(string.Join(" ", trainWagons));
                    return;
                }
                else
                {
                    int passengers = int.Parse(command);

                    for (int i = 0; i < trainWagons.Count; i++)
                    {
                        if (trainWagons[i] + passengers <= maxCapacityOfWagon)
                        {
                            trainWagons[i] += passengers;
                            break;
                        }
                    }
                }
            }
        }
    }
}