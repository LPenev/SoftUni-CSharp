using System.Text;

namespace _11._07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Person> persons = new List <Person>();
            string input = string.Empty;
            while((input = Console.ReadLine ()) != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArray[0];
                string id = inputArray[1];
                int age = int.Parse(inputArray[2]);

                
                if (persons.Any(x => x.Id == id)) 
                { 
                    var currentPerson = persons.FirstOrDefault(x => x.Id == id);
                    currentPerson.Age = age;
                    currentPerson.Name = name;
                }
                else 
                {
                    var currentPerson = new Person(name, id, age);
                    persons.Add (currentPerson);
                }
            }

            List<Person> orderedPersons = persons.OrderBy(x => x.Age).ToList();
            orderedPersons.ForEach(x => Console.WriteLine(x));
        }
    }
    public class Person
    {
        public Person(string name, string id, int age) 
        {
            Name = name;
            Id = id;
            Age = age;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; } = 0;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} with ID: {Id} is {Age} years old.");
            return sb.ToString().TrimEnd('\n');
        }
    }
}