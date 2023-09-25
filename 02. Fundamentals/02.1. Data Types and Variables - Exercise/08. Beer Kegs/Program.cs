byte loops = byte.Parse(Console.ReadLine());

string sname = default;
double svolume = 0;

for (int i = 0; i < loops; i++)
{
    string name = Console.ReadLine();
    float radius = float.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());
    //
    double volume = Math.PI * Math.Pow(2, radius) * height;
    if( svolume < volume)
    {
        svolume = volume;
        sname = name;
    }
}

// print result
Console.WriteLine(sname);