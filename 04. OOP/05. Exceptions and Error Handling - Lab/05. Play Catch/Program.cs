using System.Data;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numberArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int exceptionsCounter = 0;

            while (exceptionsCounter < 3)
            {
                try
                {


                    string[] commadArray = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string command = commadArray[0];
                    int secondIndex = 0;
                    int firstIndex = 0;

                    switch (command)
                    {
                        case "Replace":
                            firstIndex = int.Parse(commadArray[1]);
                            int element = int.Parse(commadArray[2]);

                            numberArray[firstIndex] = element;
                            break;

                        case "Print":
                            firstIndex = int.Parse(commadArray[1]);
                            secondIndex = int.Parse(commadArray[2]);

                            Console.WriteLine(String.Join(", ", numberArray[firstIndex..++secondIndex]));
                            break;

                        case "Show":

                            firstIndex = int.Parse(commadArray[1]);

                            Console.WriteLine(numberArray[firstIndex]);
                            break;
                    }

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCounter++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCounter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCounter++;
                }
            }

            Console.WriteLine(String.Join(", ", numberArray));
        }
    }
}
