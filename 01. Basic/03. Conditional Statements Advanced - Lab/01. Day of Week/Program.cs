namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //              1   Monday
            //              2   Tuesday
            //              3   Wednesday
            //              4   Thursday
            //              5   Friday
            //              6   Saturday
            //              7   Sunday
            //              -1  Error

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
