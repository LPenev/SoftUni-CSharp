namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollection<int> numbers = new List<int>();
            int start = 1;
            int end = 100;
            
            while (numbers.Count < 10 && start < 99)
            {
                start = ReadNumber(start, end);
            }

            Console.WriteLine(String.Join(", ", numbers));

            int ReadNumber(int start, int end)
            {
                int number = 0;
                try
                {
                    number = int.Parse(Console.ReadLine());

                    if (number <= start || number >= end)
                    {
                        throw new ArgumentException($"Your number is not in range {start} - {end}!");
                    }
                    numbers.Add(number);
                    start = number;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return start;
            }
        }
    }
}
