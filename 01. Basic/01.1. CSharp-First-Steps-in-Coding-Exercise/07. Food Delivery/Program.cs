namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veganMenu = int.Parse(Console.ReadLine());

            // Calc
            double sumMenu = chickenMenu * 10.35 + fishMenu * 12.40 + veganMenu * 8.15;
            double sum = sumMenu * 1.2 + 2.5;
            // Show result
            Console.WriteLine(sum);
        }
    }
}
