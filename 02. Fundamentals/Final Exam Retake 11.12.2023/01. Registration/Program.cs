using System.Numerics;

namespace _11._Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Registration")
            {
                string[] token = input.Split();
                string commnd = token[0];
                switch (commnd)
                {
                    case "Letters":
                        if (token[1] == "Lower")
                        {
                            username = username.ToLower();
                        }
                        else if (token[1] == "Upper")
                        {
                            username = username.ToUpper();
                        }
                        Console.WriteLine(username);
                        break;

                    case "Reverse":
                        int startIndex = int.Parse(token[1]);
                        int endIndex = int.Parse(token[2]);

                        if (startIndex < 0 || startIndex > username.Length || endIndex < 0 || endIndex > username.Length)
                        {
                            continue;
                        }

                        char[] reversedString = username.Substring(startIndex, endIndex - startIndex + 1).ToCharArray();
                        Array.Reverse(reversedString);
                        string reversedStr = new string(reversedString);

                        Console.WriteLine(reversedStr);
                        break;

                    case "Substring":
                        string substring = token[1];
                        if (!username.Contains(substring))
                        {
                            Console.WriteLine($"The username {username} doesn't contain {substring}.");
                            continue;
                        }
                        username = username.Replace(substring, "");
                        Console.WriteLine(username);
                        break;

                    case "Replace":
                        char charToReplace = char.Parse(token[1]);
                        username = username.Replace(charToReplace, '-');
                        Console.WriteLine(username);
                        break;

                    case "IsValid":
                        char charToValid = char.Parse(token[1]);
                        if (username.Contains(charToValid))
                        {
                            Console.WriteLine("Valid username.");
                        }
                        else
                        {
                            Console.WriteLine($"{charToValid} must be contained in your username.");
                        }
                        break;
                }
            }
        }
    }
}
