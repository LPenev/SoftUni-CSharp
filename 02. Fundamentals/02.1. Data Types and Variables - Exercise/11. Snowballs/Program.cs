using System.Numerics;

ushort numberOfSnowballs = ushort.Parse(Console.ReadLine());
BigInteger biggestSnowballValue = 0;
string result = default;

for (int i = 0; i < numberOfSnowballs; i++)
{
    ushort snowballSnow = ushort.Parse(Console.ReadLine());
    ushort snowballTime = ushort.Parse(Console.ReadLine());
    ushort snowballQuality = ushort.Parse(Console.ReadLine());

    BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

    if(snowballValue > biggestSnowballValue)
    {
        result = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";
        biggestSnowballValue = snowballValue;
    }
}

// print result
Console.WriteLine(result);
