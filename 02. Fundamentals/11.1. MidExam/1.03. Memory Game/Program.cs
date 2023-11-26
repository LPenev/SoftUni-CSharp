namespace _1._03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOfElements = Console.ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();
            int turns = 0;

            while (input != "end" && input != "END" && input != "End")
            {
                // Console.WriteLine(string.Join(" ", sequenceOfElements));
                if (sequenceOfElements.Count < 2)
                {
                    input = Console.ReadLine();
                    continue;
                }
                int[] index = input.Split().Select(int.Parse).ToArray();

                if (index[0] == index[1] || index[0] < 0 || index[0] > sequenceOfElements.Count || index[1] < 0 || index[1] > sequenceOfElements.Count - 1)
                {
                    turns++;
                    int elementsCount = sequenceOfElements.Count / 2;
                    sequenceOfElements.Insert(elementsCount, "-" + turns.ToString() + "a");
                    sequenceOfElements.Insert(elementsCount, "-" + turns.ToString() + "a");

                    Console.WriteLine("Invalid input! Adding additional elements to the board", turns + "a");
                    turns++;
                }
                else if (sequenceOfElements[index[0]] == sequenceOfElements[index[1]])
                {
                    string currentElement = sequenceOfElements[index[0]];
                    if (index[0] < index[1])
                    {
                        sequenceOfElements.RemoveAt(index[1]);
                        sequenceOfElements.RemoveAt(index[0]);
                    }
                    else
                    {
                        sequenceOfElements.RemoveAt(index[0]);
                        sequenceOfElements.RemoveAt(index[1]);
                    }
                    Console.WriteLine("Congrats! You have found matching elements - {0}!", currentElement);
                    turns++;
                }
                else
                {
                    Console.WriteLine("Try again!");
                    turns++;
                }

                input = Console.ReadLine();
            }

            if (sequenceOfElements.Count < 1 && turns > 1)
            {
                Console.WriteLine("You have won in {0} turns!", turns);
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", sequenceOfElements));
            }
        }
    }
}