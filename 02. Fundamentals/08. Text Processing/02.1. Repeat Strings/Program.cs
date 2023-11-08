using System.Text;

namespace _02._1._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var word in input)
            {
                for(int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd('\n'));
        }
    }
}