uint yield = uint.Parse(Console.ReadLine());

uint sumOfSpice = 0;
uint countDays = 0;

// calculations

while (yield >= 100)
{
    sumOfSpice += yield - 26;
    yield -= 10;
    countDays++;
}
if (sumOfSpice > 0)
{
    sumOfSpice -= 26;
}

// print result
Console.WriteLine(countDays);
Console.WriteLine(sumOfSpice);
