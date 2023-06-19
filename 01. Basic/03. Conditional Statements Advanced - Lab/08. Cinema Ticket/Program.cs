namespace _08._Cinema_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            string day = Console.ReadLine();

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    Console.WriteLine("12");
                    break;
                case "Wednesday":
                case "Thursday":
                    Console.WriteLine("14");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("16");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
