using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using var fsReader = new FileStream(inputFilePath, FileMode.Open);
            using var fsWriter = new FileStream(outputFilePath, FileMode.Create);

            int readedSize = 0;
            byte[] buffer = new byte[256];

            while ((readedSize = fsReader.Read(buffer, 0, buffer.Length)) != 0)
            {
                fsWriter.Write(buffer, 0, readedSize);
            }
        }
    }
}
