
int cencenturies = int.Parse(Console.ReadLine());
int years = cencenturies * 100;
double calc = years * 365.2422;
int days = (int)calc;
int hours = days * 24;
int minutes = hours * 60;
Console.WriteLine($"{cencenturies} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");