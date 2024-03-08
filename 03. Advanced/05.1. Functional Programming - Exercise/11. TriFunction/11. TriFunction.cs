int N = int.Parse(Console.ReadLine());

Func<string, int, bool> isEqualOrLarger = (name,n) => name.Sum(ch => ch) >= n;
Func<string[], int, Func<string, int, bool>, string> getFirstName 
    = (names, n, isMatched) => names.FirstOrDefault(name => isMatched(name, n));

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine(getFirstName(names, N, isEqualOrLarger));