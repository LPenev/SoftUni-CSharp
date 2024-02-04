namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());

            int countOfLarger = box.CompareToItem(itemToCompare);
            Console.WriteLine(countOfLarger);
        }
    }
}
