namespace _06._List_Manipulation_Basics
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
            while (inputedCommand != "end")
            {
                string[] command = inputedCommand.Split(' ');
                switch (command[0])
                {
                    case "Add":
                        AddToList(inputedNumbers, int.Parse(command[1]));
                        break;
                    case "Remove":
                        RemoveFromList(inputedNumbers, int.Parse(command[1]));
                        break;
                    case "RemoveAt":
                        RemoveAtFromList(inputedNumbers, int.Parse(command[1]));
                        break;
                    case "Insert":
                        InsertToList(inputedNumbers, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                }
                inputedCommand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", inputedNumbers));
        }

        static void AddToList(List<int> currentList, int numberToAdd)
        {
            currentList.Add(numberToAdd);
        }

        static void RemoveFromList(List<int> currentList, int numbertoRemove)
        {
            currentList.Remove(numbertoRemove);
        }

        static void RemoveAtFromList(List<int> currentList, int indexToRemove)
        {
            currentList.RemoveAt(indexToRemove);
        }

        static void InsertToList(List<int> currentList, int numberToInsert, int index)
        {
            currentList.Insert( index, numberToInsert);
        }
    }
}