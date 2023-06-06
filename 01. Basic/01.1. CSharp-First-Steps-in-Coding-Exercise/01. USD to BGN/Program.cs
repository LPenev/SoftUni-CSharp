namespace _01._USD_to_BGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables
            double usb, bgn;
            string inputTxt;
            // Show message
            Console.Write("Input USD amount: ");
            // Read Text from Conosle
            inputTxt = Console.ReadLine();
            // Convert inputed string to double
            bgn = double.Parse(inputTxt);
            // Convert usd to bgn
            usb = bgn * 1.79549;
            // Show message
            Console.Write("Your amount in BGN is: ");
            // Show Result
            Console.WriteLine(usb);
        }
    }
}
