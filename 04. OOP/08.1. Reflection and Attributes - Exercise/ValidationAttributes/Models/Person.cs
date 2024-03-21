namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        public string FullName { get; private set; }
        public int Age { get; private set; }

    }
}
