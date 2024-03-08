using System.Runtime.InteropServices;

namespace Shapes.Models
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return $"Drawing {this.GetType().Name}";
        }
    }
}
