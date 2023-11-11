namespace _104._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .ToCharArray()
                .Select(x => Convert.ToChar(x + 3));

            Console.WriteLine(string.Join("", input));
        }
    }
}