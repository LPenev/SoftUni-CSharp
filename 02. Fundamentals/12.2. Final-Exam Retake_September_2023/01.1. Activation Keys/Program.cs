//// Input                      
// abcdefghijklmnopqrstuvwxyz   
// Slice>>>2>>>6                
// Flip>>>Upper>>>3>>>14        
// Flip>>>Lower>>>5>>>7         
// Contains>>>def               
// Contains>>>deF               
// Generate                     

//    Output
// abghijklmnopqrstuvwxyz
// abgHIJKLMNOPQRstuvwxyz
// abgHIjkLMNOPQRstuvwxyz
// Substring not found!
// Substring not found!
// Your activation key is: abgHIjkLMNOPQRstuvwxyz

namespace _11._1._Activation_Keys
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
                    var containsString = inputArray[1];
                    activationKey = Contains(activationKey, containsString);
                }
                else if (command == "Flip")
                {
                    var token = inputArray[1];
                    var startIndex = int.Parse(inputArray[2]);
                    var endIndex = int.Parse(inputArray[3]);

                    activationKey = Flip(activationKey, token, startIndex, endIndex);
                }
                else if (command == "Slice")
                {
                    var startIndex = int.Parse(inputArray[1]);
                    var endIndex = int.Parse(inputArray[2]);

                    activationKey = Slice(activationKey, startIndex, endIndex);
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
        public static string Contains(string activationKey, string containsString)
        {
            if (activationKey.Contains(containsString))
            {
                Console.WriteLine($"{activationKey} contains {containsString}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
            return activationKey;
        }
        public static string Flip(string activationKey, string token, int startIndex, int endIndex)
        {
            var length = endIndex - startIndex;
            var activationKeyFlipPart = string.Empty;

            if (token == "Upper")
            {
                activationKeyFlipPart = activationKey.Substring(startIndex, length).ToUpper();
            }
            else if (token == "Lower")
            {
                activationKeyFlipPart = activationKey.Substring(startIndex, length).ToLower();
            }
            activationKey = activationKey.Remove(startIndex, length);
            activationKey = activationKey.Insert(startIndex, activationKeyFlipPart);
            Console.WriteLine(activationKey);
            return activationKey;
        }
        public static string Slice(string activationKey, int startIndex, int endIndex)
        {
            var length = endIndex - startIndex;
            activationKey = activationKey.Remove(startIndex, length);
            Console.WriteLine(activationKey);
            return activationKey;
        }
    }
}
