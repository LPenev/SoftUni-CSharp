namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine();
            string inputedString = Console.ReadLine();

            while (inputedString.Contains(toRemove))
            {
                int startIndex = inputedString.IndexOf(toRemove);
                int endIndex = toRemove.Length;

                inputedString = inputedString.Remove(startIndex, endIndex);
            }

            Console.WriteLine(inputedString);
        }
    }
}