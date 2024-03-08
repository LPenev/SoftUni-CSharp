int countOfStudets = int.Parse(Console.ReadLine());
Dictionary<string,List<decimal>> students = new Dictionary<string,List<decimal>>();

// add students to dictionary
for (int i = 0; i < countOfStudets; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string studentName = input[0];
    decimal grade = decimal.Parse(input[1]);

    if (!students.ContainsKey(studentName))
    {
        students.Add(studentName, new List<decimal>());
    }
    students[studentName].Add(grade);
}

// print result
foreach(var student in students)
{
    Console.Write($"{student.Key} -> ");
    foreach(var grade in student.Value)
    {
        Console.Write($"{grade:f2} ");
    }
    Console.WriteLine($"(avg: {student.Value.Average():f2})");
}
