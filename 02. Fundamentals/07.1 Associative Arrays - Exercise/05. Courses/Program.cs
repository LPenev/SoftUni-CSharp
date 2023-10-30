namespace _105._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputArray = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string courseName = inputArray[0];
                string studentName = inputArray[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);
            }

            foreach (var course in courses)
            {
                string courseName = course.Key;
                int registeredStudents = course.Value.Count;
                Console.WriteLine($"{courseName}: {registeredStudents}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}