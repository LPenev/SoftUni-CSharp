namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            int personCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < personCount; i++)
            {
                string[] inputArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string firstName = inputArray[0];
                string lastName = inputArray[1];
                int age = int.Parse(inputArray[2]);
                
                Person person = new(firstName, lastName, age);
                persons.Add(person);
            }

            foreach (Person person in persons.OrderBy(x=>x.FirstName).ThenBy(x=>x.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}
