namespace _11._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var activationKey = Console.ReadLine();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Generate")
            {
                var inputArray = input.Split(">>>");
                var command = inputArray[0];
                
                if (command == "Contains")
                {
                    string containsString = inputArray[1];

                    if (activationKey.Contains(containsString))
                    {
                        Console.WriteLine($"{activationKey} contains {containsString}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string token = inputArray[1];
                    int startIndex = int.Parse(inputArray[2]);
                    int length = int.Parse(inputArray[3]) - startIndex;
                    string activationKeyFlipPart = string.Empty;

                    if (token == "Upper")
                    {
                        activationKeyFlipPart = activationKey.Substring(startIndex, length).ToUpper();
                    }
                    else if(token == "Lower")
                    {
                        activationKeyFlipPart = activationKey.Substring(startIndex, length).ToLower();
                    }
                    activationKey = activationKey.Remove(startIndex, length);
                    activationKey = activationKey.Insert(startIndex, activationKeyFlipPart);
                    Console.WriteLine(activationKey);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(inputArray[1]);
                    int length = int.Parse(inputArray[2]) - startIndex;
                    activationKey = activationKey.Remove(startIndex,length);
                    Console.WriteLine(activationKey);
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
