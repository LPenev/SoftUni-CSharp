namespace PersonsInfo
{
    public class Team
    {
        private string name;
        List<Person> firstTeam;
        List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name 
        { 
            get { return this.name; }  
        }
        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam;
        public IReadOnlyCollection<Person> ReserveTeam => this.reserveTeam;

        public void AddPlayer (Person person)
        {
            if(person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
