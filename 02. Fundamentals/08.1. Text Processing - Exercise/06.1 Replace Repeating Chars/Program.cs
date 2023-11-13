namespace _106._1_Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray().ToList();
            var results = new List<char>();

            results.Add(input[0]);

            foreach (char current in input)
            {
                if (current != results.Last())
                {
                    results.Add(current);
                }
            }

            Console.WriteLine(string.Join("",results));
        }
    }
}