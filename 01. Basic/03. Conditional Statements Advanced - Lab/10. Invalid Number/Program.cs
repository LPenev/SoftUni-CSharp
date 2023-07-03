namespace _10._Invalid_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int digit = int.Parse(Console.ReadLine());
            //
            if (digit != 0 && digit < 100 || digit > 200)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
