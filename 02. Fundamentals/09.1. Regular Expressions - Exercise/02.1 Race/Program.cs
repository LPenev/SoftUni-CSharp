using System.Text;
using System.Text.RegularExpressions;

namespace _12._1_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var participants = new List<Participant>();
            var inputListNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (string current in inputListNames)
            {
                participants.Add(new Participant(current));
            }

            string letterPattern = @"[A-Za-z]";
            string digitsPattern = @"\d";

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of race")
            {
                var currentName = new StringBuilder();
                foreach (Match currentLetter in Regex.Matches(input, letterPattern))
                {
                    currentName.Append(currentLetter.Value);
                }

                string name = currentName.ToString();

                ulong currentSum = 0;
                foreach (Match currentDigit in Regex.Matches(input, digitsPattern))
                {
                    currentSum += ulong.Parse(currentDigit.Value);
                }

                Participant foundParticipant = participants.FirstOrDefault(n => n.Name == name);
                if (foundParticipant != null)
                {
                    foundParticipant.Distance += currentSum;
                }
            }

            var firstThreeParticipants = participants
                .OrderByDescending(n => n.Distance)
                .Take(3)
                .ToList();

            Console.WriteLine($"1st place: {firstThreeParticipants[0].Name}");
            Console.WriteLine($"2nd place: {firstThreeParticipants[1].Name}");
            Console.WriteLine($"3rd place: {firstThreeParticipants[2].Name}");
        }
    }

    public class Participant
    {
        public Participant(string name)
        {
            this.Name = name;
            this.Distance = 0;
        }
        public string Name { get; set; }
        public ulong Distance { get; set; }
    }
}
