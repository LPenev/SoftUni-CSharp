namespace _106._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chars = new List<char>();
            chars = Console.ReadLine().ToCharArray().ToList();

            int i = 1;
            while (i < chars.Count)
            {
                while (chars[i] == chars[i - 1])
                {
                    chars.RemoveAt(i);
                    if(i == chars.Count)
                    {
                        break;
                    }
                }
                i++;
            }

            Console.WriteLine(string.Join("",chars));
        }
    }
}