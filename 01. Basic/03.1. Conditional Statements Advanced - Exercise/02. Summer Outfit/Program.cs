namespace _02._Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int temp = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            string Outfit = "", Shoes = "";

            // calc
            if (10 <= temp && temp <= 18)
            {
                switch (time)
                {
                    case "Morning":
                        Outfit = "Sweatshirt";
                        Shoes = "Sneakers";
                        break;
                    case "Afternoon":
                    case "Evening":
                        Outfit = "Shirt";
                        Shoes = "Moccasins";
                        break;
                }

            }
            else if (18 < temp && temp <= 24)
            {
                switch (time)
                {
                    case "Morning":
                        Outfit = "Shirt";
                        Shoes = "Moccasins";
                        break;
                    case "Afternoon":
                        Outfit = "T-Shirt";
                        Shoes = "Sandals";
                        break;
                    case "Evening":
                        Outfit = "Shirt";
                        Shoes = "Moccasins";
                        break;
                }

            }
            else if (temp >= 25)
            {
                switch (time)
                {
                    case "Morning":
                        Outfit = "T-Shirt";
                        Shoes = "Sandals";
                        break;
                    case "Afternoon":
                        Outfit = "Swim Suit";
                        Shoes = "Barefoot";
                        break;
                    case "Evening":
                        Outfit = "Shirt";
                        Shoes = "Moccasins";
                        break;
                }
            }
            Console.WriteLine($"It\'s {temp} degrees, get your {Outfit} and {Shoes}.");
        }
    }
}
