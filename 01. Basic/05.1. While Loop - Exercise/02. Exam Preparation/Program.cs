using System;

namespace examPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            // varables
            string taskName = "";
            int evaluation = 0;
            int numberUnstatisGrade = 0;
            int i = 0;
            double sumGrade = 0;
            string lastProblem = "";
            // read
            int inputNumberOfUnsatisGrades = int.Parse(Console.ReadLine());

            // while loop
            while (numberUnstatisGrade != inputNumberOfUnsatisGrades)
            {
                // read
                taskName = Console.ReadLine();
                if (taskName == "Enough") break;
                lastProblem = taskName;
                evaluation = int.Parse(Console.ReadLine());
                sumGrade += evaluation;
                if(evaluation <= 4)
                {
                    numberUnstatisGrade++;
                }
                i++;
            }

            if(taskName == "Enough")
            {
                Console.WriteLine($"Average score: {sumGrade/i:f2}");
                Console.WriteLine($"Number of problems: {i}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {numberUnstatisGrade} poor grades.");
            }
        }
    }
}