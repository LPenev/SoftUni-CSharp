using System;

namespace cake
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables 
            string input = "";
            // read from console width and length of cake
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            // calc how much piece have
            int pieceCake = width * length;

            while ( pieceCake > 0)
            {
                input = Console.ReadLine();
                if( input == "STOP" )
                {
                    Console.WriteLine($"{pieceCake} pieces are left.");
                    break;
                }
                pieceCake -= int.Parse(input);
            }
            if ( input != "STOP" ) Console.WriteLine($"No more cake left! You need {Math.Abs(pieceCake)} pieces more.");
        }
    }
}