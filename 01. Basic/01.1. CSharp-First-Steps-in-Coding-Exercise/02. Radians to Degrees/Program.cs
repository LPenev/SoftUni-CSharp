namespace _02._Radians_to_Degrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get input from Console
            double radians = double.Parse(Console.ReadLine());
            // calc degrees
            double degrees = radians * 180 / Math.PI;
            // Show result
            Console.WriteLine(degrees);
        }
    }
}
