string input = string.Empty;
Dictionary<string, string> contests = new();

while ((input = Console.ReadLine()) != "end of contests")
{
    string[] inputArray = input.Split(":", StringSplitOptions.RemoveEmptyEntries) as string[];
    string contestName = inputArray[0];
    string contestPassword = encryptPassword(inputArray[1]);

    if (!contests.ContainsKey(contestName))
    {
        contests.Add(contestName, contestPassword);
    }
}

Dictionary<string, Dictionary<string, int>> users = new();

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] inputArray = input.Split("=>", StringSplitOptions.RemoveEmptyEntries) as string[];
    string contestName = inputArray[0];
    string contestPassword = encryptPassword(inputArray[1]);

    if (!contests.ContainsKey(contestName) || contests[contestName] != contestPassword)
    {
        continue;
    }

    string username = inputArray[2];
    int points = int.Parse(inputArray[3]);

    if (!users.ContainsKey(username))
    {
        users.Add(username, new Dictionary<string, int>());
    }

    if (!users[username].ContainsKey(contestName))
    {
        users[username].Add(contestName, points);
        continue;
    }

    if (users[username][contestName] < points)
    {
        users[username][contestName] = points;
    }
}

// print result
var bestCandidate = users.MaxBy(x => x.Value.Values.Sum());
Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
Console.WriteLine("Ranking: ");

foreach (var user in users.OrderBy(x => x.Key))
{
    Console.WriteLine(user.Key);

    foreach (var contest in user.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}


static string encryptPassword(string value)
{
    var data = System.Text.Encoding.ASCII.GetBytes(value);
    data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
    return Convert.ToBase64String(data);
}
