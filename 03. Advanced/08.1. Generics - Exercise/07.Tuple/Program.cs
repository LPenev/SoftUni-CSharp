namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAddress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            TupleClass<string, string> nameWithAdress 
                = new TupleClass<string, string>($"{nameAndAddress[0]} {nameAndAddress[1]}", nameAndAddress[2]);

            string[] nameAndBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            TupleClass<string, int> nameWithBeer 
                = new TupleClass<string, int>(nameAndBeer[0], int.Parse(nameAndBeer[1]));

            string[] numArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            TupleClass<int, double> numbers 
                = new TupleClass<int, double>(int.Parse(numArray[0]), double.Parse(numArray[1]));
            
            Console.WriteLine(nameWithAdress);
            Console.WriteLine(nameWithBeer);
            Console.WriteLine(numbers);
        }
    }
}
