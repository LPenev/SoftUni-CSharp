int input = int.Parse(Console.ReadLine());
string[] day = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

if (input > 0 && input < 8)
{
    Console.WriteLine(day[input - 1]);
}
else
{
    Console.WriteLine("Invalid day!");
}
