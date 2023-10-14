namespace _104._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputedNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string inputedCommand = Console.ReadLine();

            while (!inputedCommand.StartsWith("End"))
            {
                string[] command = inputedCommand.Split(' ').ToArray();

                switch (command[0])
                {
                    case "Add":
                        AddNumberToList(inputedNumbers, int.Parse(command[1]));
                        break;

                    case "Insert":
                        InsertNumberToList(inputedNumbers, int.Parse(command[1]), int.Parse(command[2]));
                        break;

                    case "Remove":
                        RemoveNumberFromList(inputedNumbers, int.Parse(command[1]));
                        break;

                    case "Shift":
                        ShiftList(inputedNumbers, command[1], int.Parse(command[2]));
                        break;
                }
                inputedCommand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", inputedNumbers));
        }

        static void AddNumberToList(List<int> inputedNumbers, int currentNumber)
        {
            inputedNumbers.Add(currentNumber);
        }

        static void InsertNumberToList(List<int> inputedNumbers,int currentNumber, int index)
        {
            if (isIndexValid(inputedNumbers, index))
            {
                inputedNumbers.Insert(index, currentNumber);
            }
        }

        static void RemoveNumberFromList(List<int> inputedNumbers, int index)
        {
            if (isIndexValid(inputedNumbers, index))
            {
                inputedNumbers.RemoveAt(index);
            }
        }

        static void ShiftList(List<int> inputedNumbers, string command, int count)
        {
            if (command == "left")
            {
                for(int i = 0; i < count; i++)
                {
                    inputedNumbers.Add(inputedNumbers[0]);
                    inputedNumbers.RemoveAt(0);
                }
            }
            else if (command == "right")
            {
                for(int i = 0;i < count; i++)
                {
                    inputedNumbers.Insert(0, inputedNumbers[inputedNumbers.Count - 1]);
                    inputedNumbers.RemoveAt(inputedNumbers.Count - 1);
                }
            }
        }

        static bool isIndexValid(List<int> inputedNumbers, int index)
        {
            if (inputedNumbers.Count <= index || index < 0)
            {
                Console.WriteLine("Invalid index");
                return false;
            }
            return true;
        }
    }
}