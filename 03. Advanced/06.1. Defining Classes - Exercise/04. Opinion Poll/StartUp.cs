using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                persons.Add(new Person(name, age));
            }

            var filtredPersnos = persons.Where(x=>x.Age > 30).OrderBy(x=>x.Name);

            foreach (Person person in filtredPersnos)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
