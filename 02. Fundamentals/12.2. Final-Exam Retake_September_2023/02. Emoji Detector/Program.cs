using System.Text.RegularExpressions;

namespace _12._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coolEmojis = new List<string>();

            string patternEmoji = @"(::|\*\*)(?<Emoji>[A-Z][a-z]{2,})\1";
            Regex emoji = new Regex(patternEmoji);
            string patternDigits = @"\d";
            Regex digits = new Regex(patternDigits);

            string input = Console.ReadLine();

            int sumDigits = 1;
            MatchCollection matchDigits = digits.Matches(input);
            foreach (Match match in matchDigits)
            {
                sumDigits *= int.Parse(match.Value);
            }

            MatchCollection matchEmojis = emoji.Matches(input);
            foreach(Match currentEmoji in matchEmojis)
            {
                int sumEmoji = 0;
                var emojiArray = currentEmoji.Groups["Emoji"].ToString().ToCharArray();
                foreach (var currentLetter  in emojiArray)
                {
                    sumEmoji += (int)currentLetter;
                }

                if (sumEmoji >= sumDigits)
                {
                    coolEmojis.Add(currentEmoji.ToString());
                }
            }
            // print result
            Console.WriteLine($"Cool threshold: {sumDigits}");
            Console.WriteLine($"{matchEmojis.Count()} emojis found in the text. The cool ones are:");
            foreach ( var currentEmoji in coolEmojis)
            {
                Console.WriteLine(currentEmoji);
            }
        }
    }
}
