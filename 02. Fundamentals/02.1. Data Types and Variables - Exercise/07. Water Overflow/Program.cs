byte tankCapacity = 255;
byte numberOfLines = byte.Parse(Console.ReadLine());

ushort tankWater = 0;
for (int i = 0; i < numberOfLines; i++)
{
    ushort waterPourIn = ushort.Parse(Console.ReadLine());
    if(tankWater + waterPourIn <= tankCapacity)
    {
        tankWater += waterPourIn;
    }
    else
    {
        Console.WriteLine("Insufficient capacity!");
    }    
}
// print result
Console.WriteLine(tankWater);