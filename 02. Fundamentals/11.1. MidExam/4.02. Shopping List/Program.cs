namespace _4._02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                .Split("!")
                .ToList();
            
            string input = Console.ReadLine();
            int index = 0;

            while (input != "Go Shopping!")
            {
                string[] commands = input.Split().ToArray();
                switch (commands[0])
                {
                    case "Urgent":
                        index = shoppingList.IndexOf(commands[1]);
                        if (index == -1)
                        {
                            shoppingList.Insert(0, commands[1]);
                        }
                        break;

                    case "Unnecessary":
                        index = shoppingList.IndexOf(commands[1]);
                        if (index != -1)
                        {
                            shoppingList.RemoveAt(index);
                        }
                        break;

                    case "Correct":
                        index = shoppingList.IndexOf(commands[1]);
                        if(index != -1)
                        {
                            shoppingList[index] = commands[2];
                        }
                        break;

                    case "Rearrange":
                        index = shoppingList.IndexOf(commands[1]);
                        if (index != -1)
                        {
                            shoppingList.Add(shoppingList[index]);
                            shoppingList.RemoveAt(index);
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}