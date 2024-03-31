
string input = Console.ReadLine();

string[] inputArray = input.Split(' ');

//
//
// for(int i = inputArray.Length - 1 ; i > 0; i--)
// {
//     Console.Write(inputArray[i] + " ");
// }
// Console.Write(inputArray[0]);

//
//
// for(int i = 0; i < inputArray.Length / 2; i++)
// {
//     string currentElement = inputArray[i];
//    inputArray[i] = inputArray[inputArray.Length - 1 - i];
//    inputArray[inputArray.Length - 1 - i] = currentElement;
// }
// for(int i = 0;i < inputArray.Length -1; i++)
// {
//     Console.Write(inputArray[i] + " ");
// }
// Console.WriteLine(inputArray[inputArray.Length -1]);

//
Console.WriteLine(string.Join(" ", inputArray.Reverse()));
