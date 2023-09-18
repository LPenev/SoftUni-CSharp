using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            string username = Console.ReadLine();
            string pass = "";
            string password = "";
            int counter = 4;

            // calculations
            for (int i = username.Length-1; i >= 0 ; i--)
            {
                pass += username[i].ToString();
            }

            do
            {
                password = Console.ReadLine();

                if (pass == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                }else
                {
                    counter--;
                    if (counter == 0)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                }

            } while (pass != password);
        }
    }
}