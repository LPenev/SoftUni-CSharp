using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace _12._The_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\#|\$|\%|\*|\.]+)(?<RacerName>[A-Za-z]+)\1=(?<HashLength>\d+)!!(?<HashCode>.*)";
            Regex regex = new Regex(pattern);

            bool isNotFound = true;
            do
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string nameOfRacer = match.Groups["RacerName"].Value;
                    int hashLength = int.Parse(match.Groups["HashLength"].Value);
                    string hashCode = match.Groups["HashCode"].Value;
                    string decryptMessage = string.Empty;

                    if (hashLength <= hashCode.Length)
                    {
                        char[] hashCodeArray = hashCode.ToCharArray();
                        for(int i = 0;i < hashLength; i++)
                        {
                            int currentChar = (int)hashCodeArray[i] + hashLength;
                            decryptMessage += (char)currentChar;
                        }


                        Console.WriteLine($"Coordinates found! {nameOfRacer} -> {decryptMessage}");
                        isNotFound = false;
                        continue;
                    }
                }
                
                Console.WriteLine("Nothing found!");

            } while (isNotFound);
        }
    }
}
