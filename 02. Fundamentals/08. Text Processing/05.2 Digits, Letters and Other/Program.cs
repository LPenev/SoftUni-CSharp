using System.Text;

namespace _05._2_Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var digits = new StringBuilder();
            var leters = new StringBuilder();
            var others = new StringBuilder();

            var input = Console.ReadLine().ToCharArray();

            foreach (char currentChar in input)
            {
                if (char.IsDigit(currentChar))
                {
                    digits.Append(currentChar);
                }
                else if (char.IsLetter(currentChar))
                {
                    leters.Append(currentChar);
                }
                else
                {
                    others.Append(currentChar);
                }
            }

            var result = new StringBuilder();
            result.AppendLine(digits.ToString());
            result.AppendLine(leters.ToString());
            result.AppendLine(others.ToString());

            Console.WriteLine(result);
        }
    }
}