namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfLeters = new List<char>();
            var listOfDigits = new List<char>();
            var listOfOthers = new List<char>();

            var input = Console.ReadLine().ToCharArray();

            foreach (char currentChar in input)
            {
                if (char.IsDigit(currentChar))
                {
                    listOfDigits.Add(currentChar);
                }
                else if (char.IsLetter(currentChar))
                {
                    listOfLeters.Add(currentChar);
                }
                else
                {
                    listOfOthers.Add(currentChar);
                }
            }

            Console.WriteLine(string.Join("", listOfDigits));
            Console.WriteLine(string.Join("", listOfLeters));
            Console.WriteLine(string.Join("", listOfOthers));
        }
    }
}