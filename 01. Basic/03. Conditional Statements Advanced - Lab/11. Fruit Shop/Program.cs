namespace _11._Fruit_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (day == "Saturday" || day == "Sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{2.70 * quantity:f2}");
                        break;
                    case "apple":
                        Console.WriteLine($"{1.25 * quantity:f2}");
                        break;
                    case "orange":
                        Console.WriteLine($"{0.90 * quantity:f2}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{1.60 * quantity:f2}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{3.00 * quantity:f2}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{5.60 * quantity:f2}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{4.20 * quantity:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{2.50 * quantity:f2}");
                        break;
                    case "apple":
                        Console.WriteLine($"{1.20 * quantity:f2}");
                        break;
                    case "orange":
                        Console.WriteLine($"{0.85 * quantity:f2}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{1.45 * quantity:f2}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{2.70 * quantity:f2}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{5.50 * quantity:f2}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{3.85 * quantity:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
