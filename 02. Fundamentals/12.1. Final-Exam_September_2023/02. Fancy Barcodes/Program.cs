using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex barcode = new Regex(@"@#+(?<Barcode>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z])@#+");
            Regex digits = new Regex(@"\d+");

            int lineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineCount; i++)
            {
                string input = Console.ReadLine();
                Match match = barcode.Match(input);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                MatchCollection number = digits.Matches(match.Groups["Barcode"].Value);
                if (number.Count() > 0)
                {
                    string result = String.Join("", number.Select(x=>x.Value));
                    Console.WriteLine($"Product group: {result}");
                }
                else
                {
                    Console.WriteLine("Product group: 00");
                }
            }
        }
    }
}
