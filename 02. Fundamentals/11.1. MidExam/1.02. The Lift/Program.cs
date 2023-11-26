namespace _1._02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            int[] liftWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int lastWagon = 0;
            for (int i = 0; i < liftWagons.Length; i++)
            {
                int current = 4 - liftWagons[i];
                if (current > 0)
                {
                    if (countOfPeople - current < 0)
                    {
                        current = countOfPeople;
                    }

                    countOfPeople -= current;
                    liftWagons[i] += current;
                    lastWagon = liftWagons[i];
                }

                if (countOfPeople == 0)
                {
                    if (!(liftWagons.Length - 1 == i && lastWagon == 4))
                    {
                        Console.WriteLine("The lift has empty spots!");
                    }
                    Console.WriteLine(string.Join(" ", liftWagons));
                    return;
                }

            }

            Console.WriteLine("There isn't enough space! {0} people in a queue!", countOfPeople);
            Console.WriteLine(string.Join(" ", liftWagons));
        }
    }
}