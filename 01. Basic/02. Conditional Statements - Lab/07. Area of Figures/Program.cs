namespace _07._Area_of_Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double result, side, side1, side2;

            string fig = Console.ReadLine();
            if (fig == "square")
            {
                side = double.Parse(Console.ReadLine());
                side *= side;
                Console.WriteLine($"{side:f3}");
            }
            else if (fig == "rectangle")
            {
                side1 = double.Parse(Console.ReadLine());
                side2 = double.Parse(Console.ReadLine());
                result = side1 * side2;
                Console.WriteLine($"{result:f3}");

            }
            else if (fig == "circle")
            {
                side1 = double.Parse(Console.ReadLine());
                result = Math.PI * Math.Pow(side1, 2);
                Console.WriteLine($"{result:f3}");
            }
            else if (fig == "triangle")
            {
                side1 = double.Parse(Console.ReadLine());
                side2 = double.Parse(Console.ReadLine());
                result = (side1 * side2) / 2;
                Console.WriteLine($"{result:f3}");
            }
        }
    }
}
