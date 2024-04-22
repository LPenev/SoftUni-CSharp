namespace _105._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombIndex = numbers.IndexOf(bomb[0]);
            int bombPower = bomb[1];
            while (bombIndex >= 0)
            {
                RemoveBomb(numbers, bombIndex, bombPower);
                bombIndex = numbers.IndexOf(bomb[0]);
            }

            Console.WriteLine(numbers.Sum());
        }

        static void RemoveBomb(List<int> numbers, int bombIndex, int bombPower)
        {
            int minPowerIndex = Math.Max(0, bombIndex - bombPower);
            int maxPowerIndex = Math.Min(numbers.Count - 1 , bombIndex + bombPower);

            for(int i =  maxPowerIndex; i >= minPowerIndex; i--)
            {
                numbers.RemoveAt(i);
            }
        }
    }
}