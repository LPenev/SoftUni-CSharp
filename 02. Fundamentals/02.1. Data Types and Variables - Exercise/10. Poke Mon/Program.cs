// N = powerOfPoking
// M = distanceBetweenTargets
// Y = depletionFactor
//
int powerOfPoking = int.Parse(Console.ReadLine());
int distanceBetweenTargets  = int.Parse(Console.ReadLine());
byte depletionFactor  = byte.Parse(Console.ReadLine());

double halfPower = powerOfPoking * 0.5;

int pokingCounter = 0;
//
while (distanceBetweenTargets <= powerOfPoking)
{
    powerOfPoking -= distanceBetweenTargets;
    pokingCounter++;

    if (powerOfPoking == halfPower && depletionFactor != 0)
    {
        powerOfPoking /= depletionFactor;
    }
}

Console.WriteLine(powerOfPoking);
Console.WriteLine(pokingCounter);
