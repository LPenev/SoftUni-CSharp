namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            string currentLine = string.Empty;
            int count = 0;
            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    while ((currentLine = reader.ReadLine()) != null)
                    {

                        if (++count % 2 == 0)
                        {
                            writer.WriteLine(currentLine);
                        }
                    }
                }
            }
        }
    }
}