Func<string, int[]> readIntegers = input => input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
.Select(int.Parse)
.ToArray();

int[] inputArray = readIntegers(Console.ReadLine());

Controler(Console.ReadLine(), inputArray);

void Controler(string command, int[] numbers)
{
    Func<int[], int[]> calculator = null;
    Action<int[]> printer = numbers => Console.WriteLine(String.Join(" ", numbers));

    switch (command)
    {
        case "add":
            calculator = number => number.Select(x => ++x).ToArray();
            numbers = calculator(numbers);
            break;

        case "multiply":
            calculator = number => number.Select(x => x * 2).ToArray();
            numbers = calculator(numbers);
            break;

        case "subtract":
            calculator = number => number.Select(x => --x).ToArray();
            numbers = calculator(numbers);
            break;

        case "print":
            printer(numbers);
            break;

        case "end":
            return;
    }

    Controler(Console.ReadLine(), numbers);
}
