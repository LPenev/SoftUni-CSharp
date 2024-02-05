namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            TupleClass<string, string, string> line1
                = new TupleClass<string, string, string>
                ($"{array1[0]} {array1[1]}", array1[2], array1[3]);

            string[] array2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            TupleClass<string, int, bool> line2
                = new TupleClass<string, int, bool>
                (array2[0], int.Parse(array2[1]), array2[2] == "drunk");

            string[] array3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            TupleClass<string, double, string> line3
                = new TupleClass<string, double, string>
                (array3[0], double.Parse(array3[1]), array3[2]);

            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
        }
    }
}
