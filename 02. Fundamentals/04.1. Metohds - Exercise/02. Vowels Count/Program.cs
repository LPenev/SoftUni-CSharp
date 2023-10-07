namespace _1102._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = CountOfVowels(input.ToLower());
            Console.WriteLine(result);
        }

        static int CountOfVowels(string inputedText)
        {
            int counter = 0;
            for (int i = 0; i < inputedText.Length; i++)
            {
                if (inputedText[i] == 'a' 
                    || inputedText[i] == 'e'
                    || inputedText[i] == 'i'
                    || inputedText[i] == 'o'
                    || inputedText[i] == 'u')
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}