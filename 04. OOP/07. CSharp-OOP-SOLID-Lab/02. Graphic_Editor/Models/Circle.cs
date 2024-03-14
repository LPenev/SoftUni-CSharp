using Models.Interfaces;
using System;

namespace Models
{
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Circle");
        }
    }
}
