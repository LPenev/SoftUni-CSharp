namespace _2._03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            double average = array.Average();

            int[] reversedArray = array.OrderByDescending(c => c).ToArray();

            int counter = 0;
            
            for(int i = 0; i < reversedArray.Length; i++)
            {
                if (reversedArray[i] > average)
                {
                    if (counter == 5)
                    {
                        break;
                    }
                    else if (counter != 0)
                    {
                        Console.Write(" ");
                    }
                    
                    Console.Write(reversedArray[i]);
                    counter++;
                }
            }

            if(counter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}