namespace _05._Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberfDyedEggs = int.Parse(Console.ReadLine());
            
            // init vars 
            int countRedEggs = 0;
            int countOrangeEggs = 0;
            int countBlueEggs = 0;
            int countGreenEggs = 0;

            int maxCountEggs = int.MinValue;
            string MaxCountColor = "";

            for (int i = 0; numberfDyedEggs > i; i++)
            {
                string currentColor = Console.ReadLine().Trim();
                switch (currentColor)
                {
                    case "red":
                        countRedEggs++;
                        break;
                    case "orange":
                        countOrangeEggs++;
                        break;
                    case "blue":
                        countBlueEggs++;
                        break;
                    case "green":
                        countGreenEggs++;
                        break;
                }
            }

            if (countRedEggs > maxCountEggs)
            {
                maxCountEggs = countRedEggs;
                MaxCountColor = "red";
            }
            if (countOrangeEggs > maxCountEggs)
            {
                maxCountEggs = countOrangeEggs;
                MaxCountColor = "orange";
            }
            if (countBlueEggs > maxCountEggs)
            {
                maxCountEggs = countBlueEggs;
                MaxCountColor = "blue";
            }
            if (countGreenEggs > maxCountEggs)
            {
                maxCountEggs = countGreenEggs;
                MaxCountColor = "green";
            }

            // print result
            Console.WriteLine($"Red eggs: {countRedEggs}");
            Console.WriteLine($"Orange eggs: {countOrangeEggs}");
            Console.WriteLine($"Blue eggs: {countBlueEggs}");
            Console.WriteLine($"Green eggs: {countGreenEggs}");
            Console.WriteLine($"Max eggs: {maxCountEggs} -> {MaxCountColor}");
        }
    }
}
