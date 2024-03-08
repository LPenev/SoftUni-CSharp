namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");

            int personsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personsCount; i++)
            {
                string[] inputArray = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputArray[0];
                string lastName = inputArray[1];
                int age = int.Parse(inputArray[2]);
                decimal salary = decimal.Parse(inputArray[3]);

                try
                {
                    Person person = new(firstName, lastName, age, salary);
                    team.AddPlayer(person);

                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
