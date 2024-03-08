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
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = inputArray[0];
                string lastName = inputArray[1];
                int age = int.Parse(inputArray[2]);
                decimal salary = decimal.Parse(inputArray[3]);

                try
                {
                    Person person = new(firstName, lastName, age, salary);
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            decimal perzentage = decimal.Parse(Console.ReadLine());

            foreach (Person person in persons)
            {
                person.IncreaseSalary(perzentage);
                Console.WriteLine(person);
            }
        }
    }
}
