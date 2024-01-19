namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    string currentLine = string.Empty;
                    int counter = 1;

                    while((currentLine = reader.ReadLine()) != null)
                    {
                        currentLine = $"{counter}. " + currentLine;
                        writer.WriteLine(currentLine);
                        counter++;
                    }
                }
            }
        }
    }
}
