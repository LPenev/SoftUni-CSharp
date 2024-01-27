namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                family.AddMember(new Person(name, age));
            }

            var oldestPerson = family.GetOldestPerson();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
