﻿namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get; private set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
