namespace _06._World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input variables
            double record = double.Parse(Console.ReadLine());
            double lengthMetri = double.Parse(Console.ReadLine());
            double swimming = double.Parse(Console.ReadLine());

            // Calc times
            double extraTime = Math.Floor(lengthMetri / 15) * 12.5;
            double times = lengthMetri * swimming + extraTime;

            // show result
            if (record > times)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {times:f2} seconds.");
            }
            else
            {
                times -= record;
                Console.WriteLine($"No, he failed! He was {times:f2} seconds slower.");
            }
        }
    }
}
