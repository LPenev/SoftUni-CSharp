namespace _01._Agency_Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read inputs 
            string avioComplany = Console.ReadLine();
            int numberOfAdultTickets = int.Parse(Console.ReadLine());
            int numberOfAdultChildrenTickets = int.Parse(Console.ReadLine());
            double netPricePerAdultTicket = double.Parse(Console.ReadLine());
            double priceOfServiceCharge = double.Parse(Console.ReadLine());
            double amountOfMoneyFromTickets = 0;

            double pricePerAdultTicket = netPricePerAdultTicket + priceOfServiceCharge;

            if (numberOfAdultChildrenTickets > 0)
            {
                double pricePerChildrenTicket = netPricePerAdultTicket * 0.3 + priceOfServiceCharge;
                amountOfMoneyFromTickets = (pricePerAdultTicket * numberOfAdultTickets) + (pricePerChildrenTicket * numberOfAdultChildrenTickets);
            }
            else
            {
                amountOfMoneyFromTickets = pricePerAdultTicket * numberOfAdultTickets;
            }

            double Profit = amountOfMoneyFromTickets * 0.20;

            Console.WriteLine($"The profit of your agency from {avioComplany} tickets is {Profit:f2} lv.");
        }
    }
}
