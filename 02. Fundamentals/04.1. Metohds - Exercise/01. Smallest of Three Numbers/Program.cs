namespace _101._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputedNummerA = int.Parse(Console.ReadLine());
            int inputedNummerB = int.Parse(Console.ReadLine());
            int inputedNummerC = int.Parse(Console.ReadLine());
            int result = GetSmalltestNumber(inputedNummerA, inputedNummerB, inputedNummerC);
            Console.WriteLine(result);
        }

        static int GetSmalltestNumber(int inputedNumberA, int inputedNumberB, int inputedNumberC)
        {
            int result = 0;
            if (inputedNumberA <= inputedNumberB && inputedNumberA <= inputedNumberC) 
            { 
                result = inputedNumberA;
            }
            else if (inputedNumberB <= inputedNumberA && inputedNumberB <= inputedNumberC)
            {
                result = inputedNumberB;
            }
            else
            {
                result = inputedNumberC;
            }
            return result;
        }
    }
}