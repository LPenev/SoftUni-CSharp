namespace _03._New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            string flowers = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double sum = 0;

            // Calc
            switch (flowers)
            {
                case "Roses":
                    sum = countFlowers * 5;
                    if (countFlowers > 80)
                    {
                        sum *= 0.9;
                    }
                    break;
                case "Dahlias":
                    sum = countFlowers * 3.8;
                    if (countFlowers > 90)
                    {
                        sum *= 0.85;
                    }
                    break;
                case "Tulips":
                    sum = countFlowers * 2.8;
                    if (countFlowers > 80)
                    {
                        sum *= 0.85;
                    }
                    break;
                case "Narcissus":
                    sum = countFlowers * 3;
                    if (countFlowers < 120)
                    {
                        sum *= 1.15;
                    }
                    break;
                case "Gladiolus":
                    sum = countFlowers * 2.5;
                    if (countFlowers < 80)
                    {
                        sum *= 1.2;
                    }
                    break;
            }
            // if have budget print result.
            if (budget >= sum)
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {flowers} and {budget - sum:f2} leva left.");
            }
            // if have't budget print result.
            else
            {
                Console.WriteLine($"Not enough money, you need {sum - budget:f2} leva more.");
            }
        }
    }
}
