using Models.Interfaces;
using System;

namespace Models
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Square");
        }
    }
}
