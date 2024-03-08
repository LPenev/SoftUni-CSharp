namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader inputStreamReader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();

            int count = 0;
            string line = string.Empty;

            while (line != null)
            {
                line = inputStreamReader.ReadLine();

                if(count%2 == 0)
                {
                    string replacedCharsLine = ReplaceChars(line);
                    string reversedString = ReverseString(replacedCharsLine);

                    sb.AppendLine(reversedString);
                }
            
                count++;
            }

            return sb.ToString().TrimEnd();
        }

        private static string ReplaceChars(string line)
        {
            char[] charsToReplace = { '-', ',', '.', '!', '?' };
            char newChar = '@';
            StringBuilder sb = new StringBuilder(line);

            foreach (char currentChar in charsToReplace)
            {
                sb.Replace(currentChar, newChar);
            }

            return sb.ToString();
        }

        private static string ReverseString(string line)
        {
            string[] currentLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return String.Join(" ", currentLine);
        }
    }
}
