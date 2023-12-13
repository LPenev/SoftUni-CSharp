
double inputA = double.Parse(Console.ReadLine());
double inputB = double.Parse(Console.ReadLine());
double eps = 0.000001;

if( Math.Abs(inputA - inputB) < eps)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}
