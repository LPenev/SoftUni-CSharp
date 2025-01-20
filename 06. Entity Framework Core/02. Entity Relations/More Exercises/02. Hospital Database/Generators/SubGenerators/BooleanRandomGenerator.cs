namespace P01_HospitalDatabase.Generators.SubGenerators
{
    internal class BooleanRandomGenerator
    {
        internal static bool Next()
        {
            var random = new Random();
            return random.Next(2) == 1;
        }
    }
}
