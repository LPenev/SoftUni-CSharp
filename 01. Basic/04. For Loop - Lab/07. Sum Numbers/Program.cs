namespace _07._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int y = int.Parse(Console.ReadLine());
                sum += y;
            }
            Console.WriteLine(sum);
        }
    }
}
