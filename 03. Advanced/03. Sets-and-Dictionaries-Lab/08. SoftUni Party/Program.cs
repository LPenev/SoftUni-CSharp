HashSet<string> vipGuests = new HashSet<string>();
HashSet<string> regularGuests = new HashSet<string>();

string input = string.Empty;
while ((input = Console.ReadLine()) != "PARTY")
{
    if (char.IsDigit(input[0]))
    {
        vipGuests.Add(input);
    }
    else
    {
        regularGuests.Add(input);
    }
}

while ((input = Console.ReadLine()) != "END")
{
    if (char.IsDigit(input[0]))
    {
        vipGuests.Remove(input);
    }
    else
    {
        regularGuests.Remove(input);
    }
}

// print result
Console.WriteLine(vipGuests.Count + regularGuests.Count);
foreach (string number in vipGuests)
{
    Console.WriteLine(number);
}

foreach (string number in regularGuests)
{
    Console.WriteLine(number);
}
