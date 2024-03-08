namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var readFirstFile = new StreamReader(firstInputFilePath);
            using(readFirstFile)
            {

                var readSecondFile = new StreamReader(secondInputFilePath);
                using(readSecondFile)
                {

                    var outputFile = new StreamWriter(outputFilePath);
                    using (outputFile)
                    {
                        bool isFirstFileNoOver = true;
                        bool isSecondFileNoOver = true;

                        while(isFirstFileNoOver || isSecondFileNoOver)
                        {
                            string currentLineFirstFile = readFirstFile.ReadLine();

                            if(currentLineFirstFile != null)
                            {
                                outputFile.WriteLine(currentLineFirstFile);
                            }
                            else
                            {
                                isFirstFileNoOver = false;
                            }

                            string currentLineSecondFile = readSecondFile.ReadLine();

                            if (currentLineSecondFile != null)
                            {
                                outputFile.WriteLine(currentLineSecondFile);
                            }
                            else
                            {
                                isSecondFileNoOver = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
