namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            RandomizeString(input);
            Console.WriteLine(string.Join(Environment.NewLine, input));
        }

        static void RandomizeString(string[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            { 
                int randomPosition = random.Next(0,array.Length-1);
                string current = array[i];
                array[i] = array[randomPosition];
                array[randomPosition] = current;
            }
        }
    }
}