using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace _14._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string msgPattern = @"[SsTtAaRr]";
            string decryptPattern = @"@(?<Planet>[A-Za-z]+)([^@\-!:>]*):(?<Population>\d+)([^@\-!:>]*)!(?<Command>A|D)!([^@\-!:>]*)->(?<Soldiers>\d+)";
            var messages = new List<Message>();

            int messageCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messageCount; i++)
            {
                var encryptMessage = Console.ReadLine();
                var decryptionKey = Regex.Matches(encryptMessage,msgPattern).Count();

                var msgBuilder = new StringBuilder();
                for(int j = 0; j < encryptMessage.Length; j++)
                {
                    msgBuilder.Append((char)(encryptMessage[j]-decryptionKey));
                }
                string decryptedMessage = msgBuilder.ToString();

                Match message = Regex.Match(decryptedMessage, decryptPattern);
                if (!message.Success)
                {
                    continue;
                }
                string planetName = message.Groups["Planet"].Value;
                uint population = uint.Parse(message.Groups["Population"].Value);
                string command = message.Groups["Command"].Value;
                uint soldiersCount = uint.Parse(message.Groups["Soldiers"].Value);

                Message currentMessage = new Message(planetName, population, command, soldiersCount);
                messages.Add(currentMessage);
            }

            var attackPlanets = messages.Where(x => x.Command == "A").OrderBy(p=>p.PlanetName);
            var destroyedPlanets = messages.Where(x => x.Command == "D").OrderBy(p => p.PlanetName);

            // print result
            Console.WriteLine($"Attacked planets: {attackPlanets.Count()}");
            foreach (var current in attackPlanets.Select(x=>x.PlanetName))
            {
                Console.WriteLine($"-> {current}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count()}");
            foreach (var current in destroyedPlanets.Select(x=>x.PlanetName))
            {
                Console.WriteLine($"-> {current}");
            }
        }
    }
    public class Message
    {
        public Message(string planetName, uint population, string attackType, uint soldiersCount)
        {
            this.PlanetName = planetName;
            this.Population = population;
            this.Command = attackType;
            this.SoldiersCount = soldiersCount;
        }

        public string PlanetName { get; set; }
        public uint Population { get; set; }
        public string Command { get; set; }
        public uint SoldiersCount { get; set; }
    }
}