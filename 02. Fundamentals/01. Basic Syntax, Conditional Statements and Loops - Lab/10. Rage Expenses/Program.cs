using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int countLostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            // variables
            int counterMouse = 0;
            int counterKeyboard = 0;

            double expenses = 0;

            // calculations
            for (int i = 1; i <= countLostGames; i++)
            {
                counterMouse++;

                if(i%2 == 0 && counterMouse == 3)
                {
                    counterMouse = 0;
                    counterKeyboard++;
                    expenses += headsetPrice;
                    expenses += mousePrice;
                    expenses += keyboardPrice;
                    
                    if(counterKeyboard == 2)
                    {
                        expenses += displayPrice;
                        counterKeyboard = 0;
                    }
                }
                else if (i%2 == 0)
                {
                    expenses += headsetPrice;
                }

                if(counterMouse == 3)
                {
                    counterMouse = 0;
                    expenses += mousePrice;
                }

            }

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}