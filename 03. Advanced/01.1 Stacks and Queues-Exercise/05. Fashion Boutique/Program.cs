namespace _15._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int boxCapacity = int.Parse(Console.ReadLine());

            Stack<int> racks = new Stack<int>();

            int sum = 0;
            for(int i = 0; i < inputArray.Length; i++)
            {
                if(sum + inputArray[i] > boxCapacity)
                {
                    racks.Push(sum);
                    sum = inputArray[i];
                }
                else
                {
                    sum += inputArray[i];
                }
            }

            if(sum > 0)
            {
                racks.Push(sum);
            }

            Console.WriteLine(racks.Count);
        }
    }
}
