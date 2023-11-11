namespace _103._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            int startIndex = input.LastIndexOf('\\') + 1;
            int endIndex = input.LastIndexOf('.');
            var filename = input.Substring(startIndex, endIndex - startIndex);

            startIndex = endIndex + 1;
            endIndex = input.Length - startIndex;

            var extension = input.Substring(startIndex, endIndex);
            
            Console.WriteLine($"File name: {filename}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}