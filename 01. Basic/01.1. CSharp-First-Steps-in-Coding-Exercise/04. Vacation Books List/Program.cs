namespace _04._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            int countPages = int.Parse(Console.ReadLine());
            int Pages = int.Parse(Console.ReadLine());
            int countDays = int.Parse(Console.ReadLine());
            // Calc
            countPages /= Pages;
            countDays = countPages / countDays;

            // Show result
            Console.WriteLine(countDays);
        }
    }
}
