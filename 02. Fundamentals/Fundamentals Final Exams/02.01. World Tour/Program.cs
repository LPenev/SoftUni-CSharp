namespace _02._01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stops = Console.ReadLine();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Travel")
            {
                var inputArray = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var command = inputArray[0];

                switch (command)
                {
                    case "Add Stop":
                        var index = int.Parse(inputArray[1]);
                        if (index >= 0 && index < stops.Length)
                        {
                            var str = inputArray[2];
                            stops = stops.Insert(index, str);
                        }
                        break;

                    case "Remove Stop":
                        var startIndex = int.Parse(inputArray[1]);
                        var endIndex = int.Parse(inputArray[2]);

                        if (startIndex >= 0 && startIndex < stops.Length && endIndex < stops.Length)
                        {
                            var length = endIndex - startIndex + 1;
                            stops = stops.Remove(startIndex, length);
                        }
                        break;

                    case "Switch":
                        var oldString = inputArray[1];

                        if (stops.Contains(oldString))
                        {
                            var newString = inputArray[2];
                            stops = stops.Replace(oldString, newString);
                        }
                        break;

                }
                Console.WriteLine(stops);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
