namespace _1107._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            NxN_Matrix(input);
        }

        static void NxN_Matrix(int inputedValue)
        {
            for (int i = 0; i < inputedValue; i++)
            {
                for(int j = 0; j < inputedValue; j++)
                {
                    Console.Write(inputedValue + " ");
                }

                Console.WriteLine();
            }
        }
    }
}