int countOfUSers = int.Parse(Console.ReadLine());

HashSet<string> users = new HashSet<string>();

for(int i = 0; i < countOfUSers; i++)
{
    users.Add(Console.ReadLine());
}

foreach(string user in users)
{
    Console.WriteLine(user);
}