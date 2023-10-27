namespace _101._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chars = new Dictionary<char,int>();
            string inputedText = string.Join("", Console.ReadLine().Split());

            foreach(var currentChar in inputedText)
            {
                if (!chars.ContainsKey(currentChar))
                {
                    chars.Add(currentChar, 1);
                    continue;
                }
                chars[currentChar]++;
            }

            foreach(var currentChar in chars)
            {
                Console.WriteLine($"{currentChar.Key} -> {currentChar.Value}");
            }
        }
    }
}