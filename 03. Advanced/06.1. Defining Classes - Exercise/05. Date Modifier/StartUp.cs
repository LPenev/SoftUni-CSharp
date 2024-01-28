namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            var result = DateModifier.GetDifference(startDate, endDate);
            Console.WriteLine(result);
        }
    }
}
