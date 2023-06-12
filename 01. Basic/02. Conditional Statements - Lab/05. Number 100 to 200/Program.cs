namespace _05._Number_100_to_200
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numm = int.Parse(Console.ReadLine());
            if (numm < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (numm >= 100 && numm <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
