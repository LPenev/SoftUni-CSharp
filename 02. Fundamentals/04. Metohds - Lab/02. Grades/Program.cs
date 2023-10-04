namespace _2._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2.00 – 2.99 - "fail"
            // 3.00 – 3.49 - "poor"
            // 3.50 – 4.49 - "good"
            // 4.50 – 5.49 - "very good"
            // 5.50 – 6.00 - "excellent"

            double input = double.Parse(Console.ReadLine());
            gradesToWord(input);
        }

        static void gradesToWord(double grade)
        {
            if(grade >= 2 && grade < 3)
            {
                Console.WriteLine("Fail");
            }
            else if (grade < 3.5)
            {
                Console.WriteLine("Poor");
            }
            else if(grade < 4.5)
            {
                Console.WriteLine("Good");
            }
            else if (grade < 5.5)
            {
                Console.WriteLine("Very good");
            }
            else if(grade <= 6)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}