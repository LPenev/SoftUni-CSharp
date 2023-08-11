using System;

namespace theMostPowerfull
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int winnerPoints = 0;
            string winnerWord = null;

            // read from console
            string input = Console.ReadLine();

            // calculations
            while (input  != "End of words")
            {
                double sumPoints = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    sumPoints += (int)input[i];
                }
                string ch0 = input[0].ToString();
                if (ch0 == "a" || ch0 == "e" || ch0 == "i" || ch0 == "o" || ch0 == "u" || ch0 == "y" || ch0 == "A" || ch0 == "E" || ch0 == "I" || ch0 == "O" || ch0 == "U" || ch0 == "Y")
                {
                    sumPoints *= input.Length;
                }
                else
                {
                    sumPoints = Math.Floor((double)sumPoints / input.Length);
                }

                if(sumPoints > winnerPoints)
                {
                    winnerPoints = (int)sumPoints;
                    winnerWord = input;
                }

                input = Console.ReadLine();
            }

            // print result
            Console.WriteLine($"The most powerful word is {winnerWord} - {winnerPoints}");
        }
    }
}