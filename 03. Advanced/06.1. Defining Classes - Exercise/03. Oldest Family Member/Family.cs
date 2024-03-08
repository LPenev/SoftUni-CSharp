namespace DefiningClasses
{
    internal class Family
    {
        private List<Person> people = new List<Person>();

        public List<Person> People { get { return people; } set { people = value; } }

        public Family()
        {
            List<Person> list = new List<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestPerson()
        {
            return People.MaxBy(x => x.Age);
        }
    }
}
