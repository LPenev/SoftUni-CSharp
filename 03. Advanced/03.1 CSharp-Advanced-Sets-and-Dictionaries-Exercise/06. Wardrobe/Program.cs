int n = int.Parse(Console.ReadLine());
Dictionary<string, Dictionary<string, int>> colors = new();

for (int i = 0; i < n; i++)
{
    string[] inputArray = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
    string color = inputArray[0];

    if (!colors.ContainsKey(color))
    {
        colors.Add(color, new Dictionary<string, int>());
    }

    foreach (string cloth in inputArray[1].Split(","))
    {
        if (!colors[color].ContainsKey(cloth))
        {
            colors[color].Add(cloth, 0);
        }

        colors[color][cloth]++;
    }
}

string[] searchArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string clothToSearch = searchArray[1];

// print result
foreach (var current in colors)
{
    Console.WriteLine($"{current.Key} clothes:");

    foreach (var cloth in current.Value)
    {
        string result = $"* {cloth.Key} - {cloth.Value}";

        if (cloth.Key == clothToSearch)
        {
            result +=" (found!)";
        }

        Console.WriteLine(result);
    }
}
