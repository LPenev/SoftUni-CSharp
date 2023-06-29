using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            string currentTab;
            // read from console
            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < openTabs; i++)
            {
                currentTab = Console.ReadLine();
                switch (currentTab)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
                        break;
                }
            }
                if( salary <= 0 )
                {
                    Console.WriteLine("You have lost your salary.");
                }
                else
                {
                    Console.WriteLine(salary);
                }

        }
    }
}