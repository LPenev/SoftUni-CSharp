namespace _03._Painting_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read inputs 
            string sizeOfEggs = Console.ReadLine().Trim();
            string colorOfEggs = Console.ReadLine().Trim();
            int numberOfLots = int.Parse(Console.ReadLine());

            // set price of eggs
            double priceOfLots = 0;

            switch (sizeOfEggs)
            {
                case "Large":
                    switch (colorOfEggs)
                    {
                        case "Red":
                            priceOfLots = 16;
                            break;

                        case "Green":
                            priceOfLots = 12;
                            break;

                        case "Yellow":
                            priceOfLots = 9;
                            break;
                    }
                    break;

                case "Medium":
                    switch (colorOfEggs)
                    {
                        case "Red":
                            priceOfLots = 13;
                            break;

                        case "Green":
                            priceOfLots = 9;
                            break;

                        case "Yellow":
                            priceOfLots = 7;
                            break;
                    }
                    break;

                case "Small":
                    switch (colorOfEggs)
                    {
                        case "Red":
                            priceOfLots = 9;
                            break;

                        case "Green":
                            priceOfLots = 8;
                            break;

                        case "Yellow":
                            priceOfLots = 5;
                            break;
                    }
                    break;
            }

            // calcs
            double sumOfLots = numberOfLots * priceOfLots;
            double expenses = sumOfLots * 0.35; // 35% expenses
            double sum = sumOfLots - expenses;
            
            // print result
            Console.WriteLine($"{sum:f2} leva.");
        }
    }
}
