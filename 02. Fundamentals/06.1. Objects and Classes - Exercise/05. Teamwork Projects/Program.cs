using System.Data;
using System.Text;

namespace _11._05._Teamwork_Projects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int numberOfTeams = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] inputTeams = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creatorName = inputTeams[0];
                string teamName = inputTeams[1];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Select(x => x.CreatorName).Contains(creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team currentTeam = new Team(teamName, creatorName);
                teams.Add(currentTeam);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] inputMember = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string teamMember = inputMember[0];
                string teamName = inputMember[1];

                Team team = teams.FirstOrDefault(x => x.TeamName == teamName);

                if (team == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                if (teams.Any(x => x.CreatorName == teamMember)
                    ||
                    teams.Any(x => x.Members.Contains(teamMember)))
                //teams.SelectMany(x => x.Members).Contains(teamMember))
                {
                    Console.WriteLine($"Member {teamMember} cannot join team {teamName}!");
                    continue;
                }

                team.Members.Add(teamMember);
            }

            List<Team> orderedTeamsByMembersCount = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            List<Team> disbandTeams = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            orderedTeamsByMembersCount.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Teams to disband:");

            disbandTeams.ForEach(x => Console.WriteLine(x.TeamName));
        }

    }

    public class Team
    {
        public Team(string teamName, string creatorName)
        {
            TeamName = teamName;
            CreatorName = creatorName;
        }
        public string TeamName { get; set; }
        public string CreatorName { get; set; }

        public List<string> Members { get; set; } = new List<string>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(TeamName);
            sb.AppendLine($"- {CreatorName}");

            List<string> orderedMembers = Members
                .OrderBy(x => x)
                .ToList();

            foreach (var member in orderedMembers)
            {
                sb.AppendLine($"-- {member}");
            }

            return sb.ToString().TrimEnd('\n');
        }
    }

}