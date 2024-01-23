Func<double, double> addVat = x => x * 1.2;
Func<double, string> roundToSecondDigits = x => $"{x:f2}";
Action<string> toPrint = x => Console.WriteLine(x);

double[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(addVat)
    .ToArray();

prices.Select(roundToSecondDigits)
    .ToList()
    .ForEach(toPrint);
