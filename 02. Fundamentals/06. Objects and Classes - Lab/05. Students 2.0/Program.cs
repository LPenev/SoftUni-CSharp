namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> listStudents = new List<Student>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] infoArray = input.Split();

                Student student = new Student();

                student.FirstName = infoArray[0];
                student.LastName = infoArray[1];
                student.Age = infoArray[2];
                student.HomeTown = infoArray[3];

                Student currentStudent = listStudents
                    .FirstOrDefault(x => x.FirstName == infoArray[0] && x.LastName == infoArray[1]);

                if (currentStudent != null)
                {
                    currentStudent.Age = infoArray[2];
                    currentStudent.HomeTown = infoArray[3];
                }
                else
                {
                    listStudents.Add(student);
                }

                input = Console.ReadLine();
            }

            string inputedTown = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine,
                listStudents
                .Where(x => x.HomeTown == inputedTown)
                .Select(x => $"{x.FirstName} {x.LastName} is {x.Age} years old.")));
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }

    }
}