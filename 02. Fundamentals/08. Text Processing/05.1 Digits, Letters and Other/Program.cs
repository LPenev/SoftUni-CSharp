namespace _05._1_Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string listOfLeters = string.Empty;
            string listOfDigits = string.Empty;
            string listOfOthers = string.Empty;

            var input = Console.ReadLine().ToCharArray();

            foreach (char currentChar in input)
            {
                if (char.IsDigit(currentChar))
                {
                    listOfDigits = string.Concat(listOfDigits, currentChar);
                }
                else if (char.IsLetter(currentChar))
                {
                    listOfLeters = string.Concat(listOfLeters, currentChar);
                }
                else
                {
                    listOfOthers = string.Concat(listOfOthers, currentChar);
                }
            }

            Console.WriteLine(string.Join("", listOfDigits));
            Console.WriteLine(string.Join("", listOfLeters));
            Console.WriteLine(string.Join("", listOfOthers));
        }
    }
}