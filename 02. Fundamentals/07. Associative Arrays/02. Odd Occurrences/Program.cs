namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> counts = new Dictionary<string,int>();
            string[] words = Console.ReadLine().Split();

            foreach (string word in words)
            {
                string wordToLower = word.ToLower();

                if (counts.ContainsKey(wordToLower))
                {
                    counts[wordToLower]++;
                }
                else
                {
                    counts.Add(wordToLower, 1);
                }
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}