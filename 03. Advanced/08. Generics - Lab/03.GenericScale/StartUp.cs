namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            EqualityScale<int> scale = new EqualityScale<int>(2,2);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
