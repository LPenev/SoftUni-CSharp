namespace _05.Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        private string Name { get; set; }
        private int Age { get; set; }
        private string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person otherPerson)
        {
            int result = Name.CompareTo(otherPerson.Name);

            if (result != 0)
            {
                return result;
            }

            result = Age.CompareTo(otherPerson.Age);

            if (result != 0)
            {
                return result;
            }

            return Town.CompareTo(otherPerson.Town);
        }
    }
}
