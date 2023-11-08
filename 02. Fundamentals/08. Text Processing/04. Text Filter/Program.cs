namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var banWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (string banWord in banWords)
            {
                string replaceWord = "*";
                for (int i = 1; i < banWord.Length; i++)
                {
                    replaceWord = String.Concat(replaceWord, "*");
                }

                while (text.Contains(banWord))
                {
                    text = text.Replace(banWord, replaceWord);
                }
            }

            Console.WriteLine(text);
        }
    }
}