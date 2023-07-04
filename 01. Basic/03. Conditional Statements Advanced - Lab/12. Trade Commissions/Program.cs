namespace _12._Trade_Commissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            // select city with switch-case
            switch (city)
            {
                case "Sofia":
                    if (0 <= sales && sales <= 500)
                    {
                        sales *= 0.05;
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        sales *= 0.07;
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        sales *= 0.08;
                    }
                    else if (sales > 10000)
                    {
                        sales *= 0.12;
                    }
                    break;

                case "Varna":
                    if (0 <= sales && sales <= 500)
                    {
                        sales *= 0.045;
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        sales *= 0.075;
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        sales *= 0.10;
                    }
                    else if (sales > 10000)
                    {
                        sales *= 0.13;
                    }
                    break;

                case "Plovdiv":
                    if (0 <= sales && sales <= 500)
                    {
                        sales *= 0.055;
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        sales *= 0.08;
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        sales *= 0.12;
                    }
                    else if (sales > 10000)
                    {
                        sales *= 0.145;
                    }
                    break;
            }
            // write result
            if (sales > 0 && (city == "Sofia" || city == "Varna" || city == "Plovdiv")) Console.WriteLine($"{sales:f2}");
            else Console.WriteLine("error");
        }
    }
}
