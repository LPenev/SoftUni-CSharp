namespace _102._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfIntegers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Delete":
                        int toDelete = int.Parse(command[1]);
                        listOfIntegers.RemoveAll(x => x == toDelete);
                        break;

                    case "Insert":
                        listOfIntegers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(" ", listOfIntegers));
        }
    }
}