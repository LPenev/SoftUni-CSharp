namespace ExtractSpecialBytes
{
    using System;
    using System.IO;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] bytesToExtract = File.ReadAllText(bytesFilePath)
                .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(b => byte.Parse(b))
                .ToArray();

            byte[] binaryFile = File.ReadAllBytes(binaryFilePath);

            var buffer = new List<byte>();

            foreach (byte current in binaryFile)
            {
                if (bytesToExtract.Contains(current))
                {
                    buffer.Add(current);
                }
            }

            File.WriteAllBytes(outputPath, buffer.ToArray());
        }
    }
}
