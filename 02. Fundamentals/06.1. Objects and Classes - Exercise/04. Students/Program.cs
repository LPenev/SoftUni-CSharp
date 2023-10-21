namespace _11._04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int studentsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Student currStudent = new Student(firstName, lastName, grade);

                students.Add(currStudent);
            }

            foreach (Student student in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    public class Student
    {
        // Constructor
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        // Property
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double Grade { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}