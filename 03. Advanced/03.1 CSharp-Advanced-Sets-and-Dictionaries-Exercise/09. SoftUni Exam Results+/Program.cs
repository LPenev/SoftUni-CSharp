string input = string.Empty;
SortedDictionary<string, int> users = new();
SortedDictionary<string, int> contests = new();

while ((input = Console.ReadLine()) != "exam finished")
{
    string[] inputArray = input.Split("-", StringSplitOptions.RemoveEmptyEntries) as string[];
    string username = inputArray[0];
    string language = inputArray[1];

    if (language == "banned")
    {
        users.Remove(username);
        continue;
    }

    int points = int.Parse(inputArray[2]);

    if (!users.ContainsKey(username))
    {
        users.Add(username, 0);
    }

    if (users[username] < points)
    {
        users[username] = points;
    }

    if (!contests.ContainsKey(language))
    {
        contests.Add(language, 0);
    }

    contests[language]++;
}

// print result
Console.WriteLine("Results:");
foreach (var user in users.OrderByDescending(x=>x.Value))
{
    Console.WriteLine($"{user.Key} | {users[user.Key]}");
}

Console.WriteLine("Submissions:");

foreach (var contest in contests)
{
    Console.WriteLine($"{contest.Key} - {contest.Value}");
}