namespace _202._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();
            var invidualStandings = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while((input = Console.ReadLine()) != "no more time")
            {
                string[] inputArray = input.Split(" -> ", StringSplitOptions.TrimEntries);
                string name = inputArray[0];
                string contest = inputArray[1];
                int points = int.Parse(inputArray[2]);

                if(!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new Dictionary<string, int>());
                }

                if (!contests[contest].ContainsKey(name))
                {
                    contests[contest].Add(name, 0);
                }

                if (contests[contest][name] < points)
                {
                    contests[contest][name] = points;
                }

                if (!invidualStandings.ContainsKey(name))
                {
                    invidualStandings.Add(name, new Dictionary<string, int>());
                }

                if (!invidualStandings[name].ContainsKey(contest))
                {
                    invidualStandings[name].Add(contest, 0);
                }

                if (invidualStandings[name][contest] < points)
                {
                    invidualStandings[name][contest] = points;
                }
            }

            foreach (var contest in contests)
            {
                int count = contest.Value.Count();
                Console.WriteLine($"{contest.Key}: {count} participants");

                int position = 0;
                foreach (var practicant in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    position++;
                    string username = practicant.Key;
                    int points = practicant.Value;
                    Console.WriteLine($"{position}. {username} <::> {points}");
                }
            }

            Console.WriteLine("Individual standings:");
            int positions = 0;
            foreach ( var currentPracticant in invidualStandings.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                positions++;
                string username = currentPracticant.Key;
                int totalPoints = currentPracticant.Value.Values.Sum();
                Console.WriteLine($"{positions}. {username} -> {totalPoints}");
            }
        }
    }
}