namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (var sourceStream = new FileStream(sourceFilePath, FileMode.Open))
            {
                long sizePartOne, sizePartTwo;

                if(sourceStream.Length%2 == 0)
                {
                    sizePartOne = sourceStream.Length/2;
                    sizePartTwo = sizePartOne;
                }
                else
                {
                    sizePartTwo = sourceStream.Length/2;
                    sizePartOne = sizePartTwo + 1;
                }

                using (var partOneStream = new FileStream(partOneFilePath, FileMode.Create))
                using (var partTwoStream = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] partOneArray = new byte[sizePartOne];
                    int bytesRead = sourceStream.Read(partOneArray, 0, partOneArray.Length);
                    partOneStream.Write(partOneArray, 0, bytesRead);

                    byte[] partTwoArray = new byte[sizePartTwo];
                    bytesRead = sourceStream.Read(partTwoArray, 0, partTwoArray.Length);
                    partTwoStream.Write(partTwoArray, 0, bytesRead);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using(var partOneStream = new FileStream(partOneFilePath, FileMode.Open))
            using(var partTwoStream = new FileStream(partTwoFilePath, FileMode.Open))
            {
                using(var outputStream = new FileStream(joinedFilePath, FileMode.Create))
                {
                    byte[] partOneArray = new byte[partOneStream.Length];
                    int bytesRead = partOneStream.Read(partOneArray, 0, partOneArray.Length);
                    outputStream.Write(partOneArray, 0, bytesRead);

                    byte[] partTwoArray = new byte[partTwoStream.Length];
                    bytesRead = partTwoStream.Read(partTwoArray, 0, partTwoArray.Length);
                    outputStream.Write(partTwoArray, 0, bytesRead);
                }
            }
        }
    }
}