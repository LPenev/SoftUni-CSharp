namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, List<string>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if(words.ContainsKey(word))
                {
                    words[word].Add(synonym);
                }
                else
                {
                    words.Add(word, new List<string>());
                    words[word].Add(synonym);
                }
            }

            foreach (string word in words.Keys)
            {
                Console.WriteLine($"{word} - " + string.Join(", ", words[word]));
            }
        }
    }
}