namespace _09._Yard_Greening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read console
            double place = double.Parse(Console.ReadLine());
            // calc place * price
            double cena = place * 7.61;
            // calc discount
            double suma = cena * 0.18;
            // calc final price with discount
            cena -= suma;
            // Show result
            Console.WriteLine($"The final price is: {cena} lv.");
            Console.WriteLine($"The discount is: {suma} lv.");
        }
    }
}
