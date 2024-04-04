namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double result = calculateRectangleArea(width, height);
            Console.WriteLine(result);
        }

        static double calculateRectangleArea(double width, double height)
        {
            double result = width * height;
            return result;
        }
    }
}