// Input:
//  1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
// Output:
//  (2 + 3)
//  (3 + 1)
//  (2 - (2 + 3) * 4 / (3 + 1))
    
namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var exp = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    exp.Push(i);
                } 
                else if (input[i] == ')')
                {
                    var startIndex = exp.Pop();
                    var endIndex = startIndex - i +1;
                    Console.WriteLine(input.Substring(startIndex, endIndex));
                }
            }
        }
    }
}
