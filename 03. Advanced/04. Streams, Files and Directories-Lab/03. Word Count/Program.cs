namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            List<string> words = new List<string>();

            // add all words into list
            var wordReader = new StreamReader(wordsFilePath);
            using (wordReader)
            {
                string currentLine = string.Empty;

                while ((currentLine = wordReader.ReadLine()) != null)
                {
                    string[] word = currentLine.Split().ToArray();

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (words.Contains(word[i]))
                        {
                            continue;
                        }
                        words.Add(word[i]);
                    }
                }
            }
            // End of add words into list

            // seach word in text
            var textReader = new StreamReader(textFilePath);
            using (textReader)
            {
                string currentLine = string.Empty;

                while ((currentLine = textReader.ReadLine()) != null)
                {
                    for (int i = 0; i < words.Count; i++)
                    {
                        string pattern = $"{words[i]}";
                        MatchCollection matches = Regex.Matches(currentLine, pattern, RegexOptions.IgnoreCase);

                        if (matches.Count > 0)
                        {
                            if (!wordsCount.ContainsKey(words[i]))
                            {
                                wordsCount.Add(words[i], 0);
                            }
                            wordsCount[words[i]]++;
                        }
                    }
                }
            }
            // End of seach word in text

            // Print result
            var resultWriter = new StreamWriter(outputFilePath);
            using (resultWriter)
            {
                foreach (var word in wordsCount)
                {
                    resultWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
