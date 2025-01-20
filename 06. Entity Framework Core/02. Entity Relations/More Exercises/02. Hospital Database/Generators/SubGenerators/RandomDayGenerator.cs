namespace P01_HospitalDatabase.Generators.SubGenerators;

internal class RandomDayGenerator
{
    internal static Random rnd = new Random();

    internal static DateTime NewDay(int startYear)
    {
        DateTime start = new DateTime(startYear, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(rnd.Next(range));
    }
}
