namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar motocycle = new(5,200);
            motocycle.Drive(10);
            Console.WriteLine(motocycle.Fuel);
        }
    }
}
