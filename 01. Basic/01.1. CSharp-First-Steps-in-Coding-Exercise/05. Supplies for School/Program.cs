namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from Console
            int broiHimikali = int.Parse(Console.ReadLine());
            int broiMarkeri = int.Parse(Console.ReadLine());
            int litriPreparat = int.Parse(Console.ReadLine());
            int prozentNamalenie = int.Parse(Console.ReadLine());
            // Calc
            double sum = broiHimikali * 5.8 + broiMarkeri * 7.2 + litriPreparat * 1.2;
            sum -= sum * prozentNamalenie / 100;

            // Show result
            Console.WriteLine(sum);
        }
    }
}
