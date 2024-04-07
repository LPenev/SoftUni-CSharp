namespace _1103._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char inputA = char.Parse(Console.ReadLine());
            char inputB = char.Parse(Console.ReadLine());
            StringInRange(inputA, inputB);
        }

        static void StringInRange(char inputA, char inputB)
        {
            char startChar, endChar;

            if (inputA > inputB)
            {
                startChar = inputB;
                endChar = inputA;
            }
            else
            {
                startChar = inputA;
                endChar = inputB;
            }

            for (int i = (int)startChar + 1;i < (int)endChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}