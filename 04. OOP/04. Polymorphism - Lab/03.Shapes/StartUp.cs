using Shapes.Models;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(10);
            Shape rectangle = new Rectangle(10, 20);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
        }
    }
}
