namespace _04._Cinema_Voucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal valueOfVoucher = decimal.Parse(Console.ReadLine());
            
            // init vars
            string input = string.Empty;
            int ticketCounter = 0;
            int goodsCounter = 0;

            while ((input = Console.ReadLine()) != "End")
            {

                if (input.Length > 8)
                {
                    string firstChar = input.Substring(0, 1);
                    string secondChar = input.Substring(1, 1);
                    int priceOfTicket = (int)firstChar[0] + (int)secondChar[0];

                    if(priceOfTicket > valueOfVoucher)
                    {
                        Console.WriteLine(ticketCounter);
                        Console.WriteLine(goodsCounter);
                        return;
                    }

                    ticketCounter++;
                    valueOfVoucher -= priceOfTicket;
                }
                else 
                {
                    string firstChar = input.Substring(0, 1);
                    int priceOfGoods = (int)firstChar[0];

                    if(priceOfGoods > valueOfVoucher)
                    {
                        Console.WriteLine(ticketCounter);
                        Console.WriteLine(goodsCounter);
                        return;
                    }

                    goodsCounter++;
                    valueOfVoucher -= priceOfGoods;
                }
            }

            // print result
            Console.WriteLine(ticketCounter);
            Console.WriteLine(goodsCounter);
        }
    }
}
