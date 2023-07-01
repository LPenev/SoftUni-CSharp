namespace _05._Small_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //              град   coffee   water   beer   sweets  peanuts
            //              Sofia   0.50    0.80    1.20    1.45    1.60
            //              Plovdiv 0.40    0.70    1.15    1.30    1.50
            //              Varna   0.45    0.70    1.10    1.35    1.55

            // read from console
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.5 * quantity);
                        break;
                    case "water":
                        Console.WriteLine(0.8 * quantity);
                        break;
                    case "beer":
                        Console.WriteLine(1.2 * quantity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.45 * quantity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.6 * quantity);
                        break;
                }
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.4 * quantity);
                        break;
                    case "water":
                        Console.WriteLine(0.7 * quantity);
                        break;
                    case "beer":
                        Console.WriteLine(1.15 * quantity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.3 * quantity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.5 * quantity);
                        break;
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(0.45 * quantity);
                        break;
                    case "water":
                        Console.WriteLine(0.7 * quantity);
                        break;
                    case "beer":
                        Console.WriteLine(1.1 * quantity);
                        break;
                    case "sweets":
                        Console.WriteLine(1.35 * quantity);
                        break;
                    case "peanuts":
                        Console.WriteLine(1.55 * quantity);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
