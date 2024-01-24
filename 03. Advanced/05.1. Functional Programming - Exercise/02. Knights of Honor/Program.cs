Func<string, string[]> stringToArray = words => words.Split(" ", StringSplitOptions.RemoveEmptyEntries)
.Select(name => "Sir " + name)
.ToArray();
string[] words = stringToArray(Console.ReadLine());

// print result
Action<string[]> print = words => Console.WriteLine(String.Join("\n", words));
print(words);