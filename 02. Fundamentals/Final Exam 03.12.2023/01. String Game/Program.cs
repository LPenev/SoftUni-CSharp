using System.ComponentModel.DataAnnotations;

namespace _01._String_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputedString = Console.ReadLine();

            var input = string.Empty;
            while((input = Console.ReadLine()) != "Done")
            {
                var inputArray = input.Split(" ");
                var command = inputArray[0];

                switch (command)
                {
                    case "Change":
                        var oldString = inputArray[1];
                        var replacement = inputArray[2];
                        inputedString = inputedString.Replace(oldString,replacement );
                        Console.WriteLine(inputedString);
                        break;

                    case "Includes":
                        var subString = inputArray[1];
                        bool isExist = inputedString.Contains(subString);
                        Console.WriteLine(isExist);
                        break;

                    case "End":
                        var endedTxt = inputArray[1];
                        bool isEnded = inputedString.EndsWith(endedTxt);
                        Console.WriteLine(isEnded);
                        break;

                    case "Uppercase":
                        inputedString = inputedString.ToUpper();
                        Console.WriteLine(inputedString);
                        break;

                    case "FindIndex":
                        char searchChar = char.Parse(inputArray[1]);
                        int findedIndex = inputedString.IndexOf(searchChar);
                        Console.WriteLine(findedIndex);
                        break;

                    case "Cut":
                        var startIndex = int.Parse(inputArray[1]);
                        var cutCount = int.Parse(inputArray[2]);
                        inputedString = inputedString.Substring(startIndex, cutCount);
                        Console.WriteLine(inputedString);
                        break;
                }
            }
        }
    }
}
