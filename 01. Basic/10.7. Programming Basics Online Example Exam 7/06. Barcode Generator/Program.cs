namespace _06._Barcode_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read inputs
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int firstDigitStart = start / 1000;
            int secondDigitStart = (start / 100) % 10;
            int thirdDigitStart = (start / 10) % 10;
            int fourthDigitStart = start % 10;

            int firstDigitEnd = end / 1000;
            int secondDigitEnd = (end / 100) % 10;
            int thirdDigitEnd = (end / 10) % 10;
            int fourthDigitEnd = end % 10;

            for (int i = firstDigitStart; i <= firstDigitEnd; i++)
            {
                for (int j = secondDigitStart; j <= secondDigitEnd; j++)
                {
                    for (int k = thirdDigitStart; k <= thirdDigitEnd; k++)
                    {
                        for (int l = fourthDigitStart; l <= fourthDigitEnd; l++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l % 2 != 0)
                            {
                                Console.Write("{0}{1}{2}{3} ", i, j, k, l);
                            }
                        }
                    }
                }
            }
        }
    }
}
