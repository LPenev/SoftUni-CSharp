using System.Data;

namespace _03._Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();

            string input = Console.ReadLine();
            
            while (input != "end")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Chat":
                        messages.Add(command[1]);
                        break;

                    case "Delete":
                        int index = messages.IndexOf(command[1]);
                        if(index > -1)
                        {
                            messages.RemoveAt(index);
                        }
                        break;

                    case "Edit":
                        int index1 = messages.IndexOf(command[1]);
                        messages[index1] = command[2];
                        break;

                    case "Pin":
                        int index2 = messages.IndexOf(command[1]);
                        if(index2 > -1)
                        {
                            messages.Add(messages[index2]);
                            messages.RemoveAt(index2);
                        }
                        break;

                    case "Spam":
                        if (command.Length > 1) {
                            for (int i = 1;i < command.Length; i++)
                            {
                                messages.Add((string)command[i]);
                            }
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, messages));
        }
    }
}