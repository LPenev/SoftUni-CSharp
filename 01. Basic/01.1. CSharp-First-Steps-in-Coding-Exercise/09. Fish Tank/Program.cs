namespace _09._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double prozent = double.Parse(Console.ReadLine());

            // Calc volume tank litri
            double volumeTank = length * width * height;
            volumeTank /= 1000;
            // Calc litri
            double litri = volumeTank * (1 - prozent / 100);

            // Show result
            Console.WriteLine(litri);
        }
    }
}
