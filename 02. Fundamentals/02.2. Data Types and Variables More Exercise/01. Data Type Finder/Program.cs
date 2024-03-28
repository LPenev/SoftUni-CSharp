using System.ComponentModel.DataAnnotations;

string input = Console.ReadLine();
string result = default;

while (input != "END")
{
    if (int.TryParse(input, out int result1))
    {
        result = $"{input} is integer type";
    }
    else if (float.TryParse(input, out float result2))
    {
        result = $"{input} is floating point type";
    }
    else if (char.TryParse(input, out char result3))
    {
        result = $"{input} is character type";
    }
    else if (bool.TryParse(input, out bool result4))
    {
        result = $"{input} is boolean type";
    }
    else
    {
        result = $"{input} is string type";
    }
    // print result
    Console.WriteLine(result);
    // read from console
    input = Console.ReadLine();
}
