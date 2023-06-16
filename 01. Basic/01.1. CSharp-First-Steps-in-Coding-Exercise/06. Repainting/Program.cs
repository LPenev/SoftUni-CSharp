namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            int nailon = int.Parse(Console.ReadLine());
            int boq = int.Parse(Console.ReadLine());
            int razreditel = int.Parse(Console.ReadLine());
            int chasove = int.Parse(Console.ReadLine());

            // Calc
            // nailon
            double sum = (nailon + 2) * 1.5;
            // boq
            sum = sum + (boq * 1.1) * 14.5;
            // razreditel
            sum = sum + razreditel * 5;
            // torbichki
            sum += 0.4;
            // majstori
            sum = sum + sum * 0.3 * chasove;

            // Show result
            Console.WriteLine(sum);
        }
    }
}
