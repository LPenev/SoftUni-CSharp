char input1 = char.Parse(Console.ReadLine());
char input2 = char.Parse(Console.ReadLine());
char input3 = char.Parse(Console.ReadLine());

// string text = $"{input1}{input2}{input3}";
string text2 = string.Concat(input1, input2, input3);

Console.WriteLine(text2);