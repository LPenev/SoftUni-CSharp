int countOfInputs = int.Parse(Console.ReadLine());
Dictionary<int, int> digits = new();

for(int i = 0; i < countOfInputs; i++)
{
    int current = int.Parse(Console.ReadLine());
    if (!digits.ContainsKey(current))
    {
        digits.Add(current, 0);
    }
    digits[current]++;
}

Console.WriteLine(digits.Single(x => x.Value%2 == 0).Key);