int maxLengthOfWord = int.Parse(Console.ReadLine());

Func<string, string[]> readIntegers = input => input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
.ToArray();

Func<string, int, bool> filter = (word,maxLength) => word.Length <= maxLength;

string[] words = readIntegers(Console.ReadLine());

Console.WriteLine(String.Join("\n", words.Where(x => filter(x, maxLengthOfWord))));
