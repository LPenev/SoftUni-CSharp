
double length, width, height = 0;
// read length
Console.Write("Length: ");
length = double.Parse(Console.ReadLine());
// read width
Console.Write("Width: ");
width = double.Parse(Console.ReadLine());
// read height
Console.Write("Height: ");
height = double.Parse(Console.ReadLine());
// calculation
double volume = (length * width * height) / 3;
// print result
Console.WriteLine($"Pyramid Volume: {volume:f2}");
