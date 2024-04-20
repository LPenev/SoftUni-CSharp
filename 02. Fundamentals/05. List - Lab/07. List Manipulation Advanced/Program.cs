namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputedNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isListChanged = false;

            string inputedCommand = Console.ReadLine();
            while (inputedCommand != "end")
            {
                string[] command = inputedCommand.Split(' ');
                switch (command[0])
                {
                    case "Add":
                        isListChanged = AddToList(inputedNumbers, int.Parse(command[1]));
                        break;

                    case "Remove":
                        isListChanged = RemoveFromList(inputedNumbers, int.Parse(command[1]));
                        break;

                    case "RemoveAt":
                        isListChanged = RemoveAtFromList(inputedNumbers, int.Parse(command[1]));
                        break;

                    case "Insert":
                        isListChanged = InsertToList(inputedNumbers, int.Parse(command[1]), int.Parse(command[2]));
                        break;

                    case "Contains":
                        ContainsOfList(inputedNumbers, int.Parse(command[1]));
                        break;

                    case "PrintEven":
                        string printEven = "Even";
                        PrintEvenOrOddOfList(inputedNumbers, printEven == "Even");
                        break;

                    case "PrintOdd":
                        string printOdd = "Odd";
                        PrintEvenOrOddOfList(inputedNumbers, printOdd == "Even");
                        break;

                    case "GetSum":
                        GetSumOfList(inputedNumbers);
                        break;

                    case "Filter":
                        PrintFilter(inputedNumbers, command[1], int.Parse(command[2]));
                        break;
                }
                inputedCommand = Console.ReadLine();
            }

            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", inputedNumbers));
            }
        }

        static bool AddToList(List<int> currentList, int numberToAdd)
        {
            currentList.Add(numberToAdd);
            return true;
        }

        static bool RemoveFromList(List<int> currentList, int numbertoRemove)
        {
            currentList.Remove(numbertoRemove);
            return true;
        }

        static bool RemoveAtFromList(List<int> currentList, int indexToRemove)
        {
            currentList.RemoveAt(indexToRemove);
            return true;
        }

        static bool InsertToList(List<int> currentList, int numberToInsert, int index)
        {
            currentList.Insert(index, numberToInsert);
            return true;
        }

        static void ContainsOfList(List<int> currentList, int containsNumber)
        {
            int indexOfContains = currentList.IndexOf(containsNumber);
            if(indexOfContains >= 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEvenOrOddOfList(List<int> currentList,bool isEven )
        {
            Console.WriteLine(string.Join(" ", currentList.Where(x => isEven == (x%2 == 0))));
        }

        static void GetSumOfList(List<int> currentList)
        {
            Console.WriteLine(currentList.Sum());
        }

        static void PrintFilter(List<int> currentList, string condition, int number)
        {
            switch (condition)
            {
                case "<":
                    Console.WriteLine(string.Join(" ", currentList.Where(x => x < number)));
                    break;

                case ">":
                    Console.WriteLine(string.Join(" ", currentList.Where(x => x > number)));
                    break;

                case "<=":
                    Console.WriteLine(string.Join(" ", currentList.Where(x => x <= number)));
                    break;

                case ">=":
                    Console.WriteLine(string.Join(" ", currentList.Where(x => x >= number)));
                    break;
            }
        }
    }
}