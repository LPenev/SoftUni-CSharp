namespace _19._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());
            string text = string.Empty;

            Stack<string> undo = new Stack<string>();
            undo.Push(text);

            for (int i = 0; i < commandCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        string textToAdd = input[1];
                        text += textToAdd;
                        undo.Push(text);
                        break;

                    case 2:
                        int eraseCount = int.Parse(input[1]);
                        int startIndex = text.Length - eraseCount;
                        text = text.Remove(startIndex);
                        undo.Push(text);
                        break;

                    case 3:
                        int txtPosition = int.Parse(input[1]) - 1;
                        Console.WriteLine(text[txtPosition]);
                        break;

                    case 4:
                        if (undo.Any())
                        {
                            if (text == undo.Peek())
                            {
                                undo.Pop();
                            }
                            text = undo.Pop();
                        }
                        break;
                }
            }
        }
    }
}
