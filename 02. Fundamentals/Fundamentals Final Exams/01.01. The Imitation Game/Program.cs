namespace _01._01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var message = Console.ReadLine();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Decode")
            {
                var inputArray = input.Split("|");
                var command = inputArray[0];
                switch (command)
                {
                    case "Move":
                        var numberOfLetters = int.Parse(inputArray[1]);
                        string partMessage = message.Substring(0, numberOfLetters);
                        message = message.Remove(0, numberOfLetters);
                        message += partMessage;
                        break;

                    case "Insert":
                        var index = int.Parse(inputArray[1]);
                        var value = inputArray[2];
                        message = message.Insert(index, value);
                        break;

                    case "ChangeAll":
                        var substring = inputArray[1];
                        var replacement = inputArray[2];
                        message = message.Replace(substring, replacement);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
