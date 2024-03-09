namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine()
                .Split(' ');
            int sum = 0;

            foreach (string currentElement in inputArray)
            {
                try
                {
                    int number = int.Parse(currentElement);
                    sum += number;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{currentElement}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{currentElement}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{currentElement}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
