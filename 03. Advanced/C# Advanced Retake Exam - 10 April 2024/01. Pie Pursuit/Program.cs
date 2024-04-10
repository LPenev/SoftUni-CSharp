
int[] contestantsArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] piesOfPiesArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> contestants = new Queue<int>(contestantsArray);
Stack<int> piesOfPies = new Stack<int>(piesOfPiesArray);

while (contestants.Count > 0 && piesOfPies.Count > 0)
{
    int currentContestant = contestants.Dequeue();
    int currentPie = 0;
    if (piesOfPies.Count > 0)
    {
        currentPie = piesOfPies.Pop();
    }

    if (currentContestant > currentPie)
    {
        currentContestant -= currentPie;

        if (currentContestant > 0)
        {
            contestants.Enqueue(currentContestant);
        }
    }
    else
    {
        currentPie -= currentContestant;
        if (currentPie > 0)
        {
            piesOfPies.Push(currentPie);
        }
    }

}

if (contestants.Count > 0)
{
    Console.WriteLine("We will have to wait for more pies to be baked!");
    Console.WriteLine($"Contestants left: {String.Join(", ", contestants)}");
}
else if (piesOfPies.Count > 0)
{
    Console.WriteLine("Our contestants need to rest!");
    Console.WriteLine($"Pies left: {String.Join(", ", piesOfPies)}");
}
else
{
    Console.WriteLine("We have a champion!");
}