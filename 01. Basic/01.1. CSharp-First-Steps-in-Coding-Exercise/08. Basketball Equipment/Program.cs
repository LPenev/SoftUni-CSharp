namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            int yearTax = int.Parse(Console.ReadLine());

            // Calc
            double kecove = yearTax - yearTax * 0.4;
            double ekip = kecove - kecove * 0.2;
            double topka = ekip / 4;
            double accessoari = topka / 5;
            double sum = kecove + ekip + topka + accessoari + yearTax;

            // Show result
            Console.WriteLine(sum);
        }
    }
}
