namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = SumElements(numbers);

            Console.WriteLine(string.Join(" ", result));
        }

        static List<int> SumElements(List<int> numbers)
        {
            List<int> result = new List<int>();
            int lastIndexOfNumbers = numbers.Count - 1;
            for(int i = 0;i < numbers.Count / 2; i++)
            {
                int current = numbers[i] + numbers[lastIndexOfNumbers - i];
                result.Add(current);
            }

            if(numbers.Count % 2 != 0)
            {
                result.Add(numbers[numbers.Count / 2]);
            }

            return result;
        }
    }
}