namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string inputedCommand = string.Empty;
            while ((inputedCommand = Console.ReadLine()) != "Reveal")
            {
                var commandArray = inputedCommand.Split(":|:");

                switch (commandArray[0])
                {
                    case "ChangeAll":
                        int index = 0;
                        while ((index = message.IndexOf(commandArray[1])) > 0)
                        {
                            message = message.Replace(commandArray[1], commandArray[2]);
                        }
                        break;
                    case "Reverse":
                        string reversedSubstring = new string(commandArray[1].Reverse().ToArray());
                        message = message.Replace(commandArray[1], reversedSubstring);
                        break;
                    case "InsertSpace":
                        int startIndex = int.Parse(commandArray[1]);
                        message = message.Insert(startIndex, " ");
                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
