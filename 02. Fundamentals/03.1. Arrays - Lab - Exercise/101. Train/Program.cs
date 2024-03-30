int numberOfWagons = int.Parse(Console.ReadLine());

int[] wagons = new int[numberOfWagons];
int sumAllPassengers = 0;

for (int i = 0; i < numberOfWagons; i++)
{
    wagons[i] = int.Parse(Console.ReadLine());
    sumAllPassengers += wagons[i];
}

// print result
Console.WriteLine(string.Join(" ",wagons));
Console.WriteLine(sumAllPassengers);