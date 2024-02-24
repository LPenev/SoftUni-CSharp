namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new();
            int personsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personsCount; i++)
            {
                string[] inputArray = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputArray[0];
                string lastName = inputArray[1];
                int age = int.Parse(inputArray[2]);
                decimal salary = decimal.Parse(inputArray[3]);

                Person person = new(firstName, lastName, age, salary);
                persons.Add(person);
            }
            
            decimal percentage = decimal.Parse(Console.ReadLine());

            foreach (Person person in persons)
            { 
                person.IncreaseSalary(percentage);
                Console.WriteLine(person);
            }
        }
    }
}
