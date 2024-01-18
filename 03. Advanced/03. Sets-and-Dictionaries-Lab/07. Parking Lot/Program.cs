string input = string.Empty;
HashSet<string> bases = new HashSet<string>();

// read from console and fillup HashSet
while((input = Console.ReadLine()) != "END")
{
    string[] inputArray = input.Split(", ", StringSplitOptions.RemoveEmptyEntries); 
    string command = inputArray[0];
    string regNumber = inputArray[1];

    if(command == "IN")
    {
        bases.Add(regNumber);
    }
    else if(command == "OUT")
    {
        bases.Remove(regNumber);
    }
}

// print result
if (!bases.Any()) {
    Console.WriteLine("Parking Lot is Empty");
    return;
}

foreach(var current in bases)
{
    Console.WriteLine(current);
}