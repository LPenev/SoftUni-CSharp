namespace LineNumbers
{
    using System;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                int letersCount = lines[i].Count(char.IsLetter);
                int puntuationCount = lines[i].Count(char.IsPunctuation);

                sb.AppendLine($"Line {i+1} {lines[i]} ({letersCount})({puntuationCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
