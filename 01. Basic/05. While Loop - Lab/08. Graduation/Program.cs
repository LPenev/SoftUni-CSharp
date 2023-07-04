using System;

namespace graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            bool badGrade = false;
            double grade = 0;
            double sumGrade = 0;
            string name = Console.ReadLine();

            for( i=0; i<12; i++ )
            {
                grade = double.Parse(Console.ReadLine());
                sumGrade += grade;
                if( grade <= 3 )
                {
                    if(badGrade)
                    {
                        break;
                    }
                    badGrade = true;
                }
            }

            if (badGrade)
            {
                Console.WriteLine($"{name} has been excluded at {i} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {sumGrade / i:f2}");
            }
        }
    }
}