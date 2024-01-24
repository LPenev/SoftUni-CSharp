Func<string, int[]> readIntArray = x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
.Select(int.Parse).ToArray();

int[] intArray = readIntArray(Console.ReadLine());

Action<int[]> printMin = numbers => Console.WriteLine(numbers.Min());
printMin(intArray);