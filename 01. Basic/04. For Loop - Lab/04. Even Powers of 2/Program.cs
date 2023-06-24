namespace _04._Even_Powers_of_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int n = int.Parse(Console.ReadLine());
            int num = 1;

            for (int i = 0; i <= n; i += 2)
            {
                // print num
                Console.WriteLine(num);
                // 2 of even degree
                num = num * 2 * 2;
            }
        }
    }
}
