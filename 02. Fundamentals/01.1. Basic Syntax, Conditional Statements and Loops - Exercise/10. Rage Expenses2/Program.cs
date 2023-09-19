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
            int counterHeadset = 0;
            int counterMouse = 0;
            int counterKeyboard = 0;

            bool isHeadsetBroken = false;
            bool isMouseBroken = false;

            double expenses = 0;

            // calculations
            for ( int i = 1; i <= countLostGames; i++ )
            {
                counterHeadset++;
                counterMouse++;

                if( counterHeadset == 2 )
                {
                    expenses += headsetPrice;
                    counterHeadset = 0;
                    isHeadsetBroken = true;
                }
                else
                {
                    isHeadsetBroken = false;
                }

                if( counterMouse == 3 )
                {
                    expenses += mousePrice;
                    counterMouse = 0;
                    isMouseBroken = true;
                }
                else
                {
                    isMouseBroken = false;
                }

                if( isHeadsetBroken && isMouseBroken )
                {
                    expenses += keyboardPrice;
                    counterKeyboard++;
                }

                if( counterKeyboard == 2 )
                {
                    expenses += displayPrice;
                    counterKeyboard = 0;
                }

            }

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}