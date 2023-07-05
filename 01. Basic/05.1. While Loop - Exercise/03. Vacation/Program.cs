using System;

namespace vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int daysCounter = 0;
            int spendDays = 0;
            string action = "";
            double actionMoney = 0;
            // read from console
            double vacantionPrice = double.Parse(Console.ReadLine());
            double moneyOnHand = double.Parse(Console.ReadLine());

            while(vacantionPrice > moneyOnHand && spendDays < 5)
            {
                action = Console.ReadLine();
                actionMoney = double.Parse(Console.ReadLine());
                
                // action spend
                if (action == "spend")
                {
                    moneyOnHand -= actionMoney;
                    spendDays++;
                    // can't moneyOnHand minus is.
                    if (moneyOnHand < 0) moneyOnHand = 0;
                }
                // action save
                else
                {
                    moneyOnHand += actionMoney;
                    spendDays = 0;
                }
                // increase daysCounter
                daysCounter++;
            }
            // print result
            if ( spendDays == 5 )
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            else if( vacantionPrice <= moneyOnHand )
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}