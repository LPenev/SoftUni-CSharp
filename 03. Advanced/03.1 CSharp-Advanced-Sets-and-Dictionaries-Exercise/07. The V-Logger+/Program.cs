Dictionary<string, Dictionary<string, HashSet<string>>> vlogers = new();
string input = string.Empty;
string followers = "followers";
string following = "following";

while ((input = Console.ReadLine()) != "Statistics")
{
    if (input.Contains(" joined "))
    {
        string[] inputArray = input.Split(" joined ");
        string username = inputArray[0];

        if (!vlogers.ContainsKey(username))
        {
            vlogers.Add(username, new Dictionary<string, HashSet<string>>());
            vlogers[username].Add(followers, new HashSet<string>());
            vlogers[username].Add(following, new HashSet<string>());
        }
    }
    else if (input.Contains(" followed "))
    {
        string[] inputArray = input.Split(" followed ");
        string follower = inputArray[0];
        string followed = inputArray[1];

        if (follower == followed)
        {
            continue;
        }

        if (
                 vlogers.ContainsKey(follower)
              && vlogers.ContainsKey(followed)
              && !vlogers[follower][following].Contains(followed) 
              && !vlogers[follower][followers].Contains(follower) 
           )
        {
            vlogers[follower][following].Add(followed);
            vlogers[followed][followers].Add(follower);
        }
    }
}

// print result
Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");
int count = 1;
foreach (var current in vlogers
    .OrderByDescending(x => x.Value[followers].Count)
    .ThenBy(x => x.Value[following].Count)
    )
{
    var currentVloger = vlogers[current.Key];
    Console.WriteLine($"{count}. {current.Key} : {currentVloger[followers].Count} followers, {currentVloger[following].Count} following");
    
    if(count == 1 && currentVloger[followers].Count > 0)
    {
        foreach( var follower in vlogers[current.Key][followers].OrderBy(x => x) )
        {
            Console.WriteLine($"*  {follower}");
        }
    }
    
    count++;
}