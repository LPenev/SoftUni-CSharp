using System;

namespace ages
{
    class Program
    {
        static void Main(string[] args)
        {

            // 0 - 2 – baby
            // 3 - 13 – child
            // 14 - 19 – teenager
            // 20 - 65 – adult
            // >= 66 – elder

            int age = int.Parse(Console.ReadLine());
            string text = "";

            if (age >= 0 && age < 3)
            {
                text = "baby";
            } else if (age > 2 && age < 14)
            {
                text = "child";
            }
            else if (age > 13 && age < 20)
            {
                text = "teenager";
            }
            else if (age > 19 && age < 66)
            {
                text = "adult";
            }
            else if (age > 65)
            {
                text = "elder";
            }

            // print result
            Console.WriteLine("{0}", text);
        }
    }
}