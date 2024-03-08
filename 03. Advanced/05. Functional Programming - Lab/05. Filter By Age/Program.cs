// input
int peopleCount = int.Parse(Console.ReadLine());
List<Person> persons = ReadPeople(peopleCount);

// read filters
string condition = Console.ReadLine();
int ageTreshold = int.Parse(Console.ReadLine());
string format = Console.ReadLine();

Func<Person, bool> filter = CreateFilter(condition, ageTreshold);
Action<Person> printer = CreatePrinter(format);

PrintFiltredPeople(persons, filter, printer);

List<Person> ReadPeople(int peopleCount)
{
    List<Person> persons = new List<Person>();
    
    for (int i = 0; peopleCount > i; i++)
    {
        string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        persons.Add( new Person(input[0], int.Parse(input[1])));
    }
    return persons;
}

Func<Person, bool> CreateFilter(string? condition, int ageTreshold)
{
    Func<Person, bool> filter = null;
    
    if(condition == "younger")
    {
        filter = Person => Person.Age < ageTreshold;
    }
    else if(condition == "older")
    {
        filter = Person => Person.Age >= ageTreshold;
    }

    return filter;
}
Action<Person> CreatePrinter(string? format)
{
    if(format == "name")
    {
        return person => Console.WriteLine($"{person.Name}");
    }
    else if (format == "age")
    {
        return person => Console.WriteLine($"{person.Age}");
    }
    else if (format == "name age")
    {
        return person => Console.WriteLine($"{person.Name} - {person.Age}");
    }
    throw new ArgumentException(format);
}

void PrintFiltredPeople(List<Person> persons, Func<Person, bool> filter, Action<Person> print)
{
    foreach (Person person in persons.Where(filter))
    {
        printer(person);
    }
}

public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
}
