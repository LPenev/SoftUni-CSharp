using Models.Interfaces;
using System;

namespace Models
{
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Recangle");
        }
    }
}
