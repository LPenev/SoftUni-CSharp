using System;

namespace promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            float price = 0;
            bool isError = false;

            switch (day) { 
            case "weekday":
                    if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                    {
                        price = 12;
                    }
                    else if ( age > 18 && age <=64 )
                    {
                        price = 18;
                    }
                    else
                    {
                        isError = true;
                    }
                    break;

                case "weekend":
                    if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                    {
                        price = 15;
                    }
                    else if (age >18 && age <=64)
                    {
                        price = 20;
                    }
                    else
                    {
                        isError = true;
                    }
                    break;

                case "holiday":
                    if (age >= 0 && age <= 18)
                    {
                        price = 5;
                    }
                    else if(age > 18 && age <=64)
                    {
                        price = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price = 10;
                    }
                    else
                    {
                        isError = true;
                    }
                    break;
                default:
                    isError = true;
                    break;
                }
            if(!isError)
            {
                Console.WriteLine("{0}$", price);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}