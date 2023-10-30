using System.Xml.Linq;

namespace _106._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<double>());
                }
                students[student].Add(grade);
            }

            foreach (var student in students)
            {
                string name = student.Key;
                double averageGrade = student.Value.Average();
                if(averageGrade < 4.5)
                {
                    continue;
                }
                Console.WriteLine($"{name} -> {averageGrade:f2}");
            }
        }
    }
}