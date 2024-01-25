Func<string, int[]> readIntegers = input => input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
.Select(int.Parse)
.ToArray();

Func<int[], int, int[]> checkForDevisibleBy = (input, givenInt) => input.Where(x=> x % givenInt != 0).ToArray();

Func<int[], int[]> reverseArray = digits => digits.Reverse().ToArray();

int[] inputArray = readIntegers(Console.ReadLine());
int givenInteger = int.Parse(Console.ReadLine());


int[] filtredDigits = checkForDevisibleBy(inputArray, givenInteger);
int[] revesedDigits = reverseArray(filtredDigits);

Console.WriteLine(String.Join(" ", revesedDigits));