using System.Diagnostics.CodeAnalysis;
using System.Runtime;

namespace _18._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new();
            bool isBalanced = true;

            foreach (char current in input)
            {
                if (IsOpenParentheses(current))
                {
                    stack.Push(current);
                    continue;
                }

                if (MatchParentheses(current) != 'x')
                {
                    if (!stack.Any())
                    {
                        isBalanced = false;
                        break;
                    }

                    char openParenthes = MatchParentheses(current);
                    
                    if(stack.Pop() != openParenthes)
                    {
                        isBalanced = false;
                        break;
                    }
                }

            }

            if (stack.Any() || !isBalanced)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }

        static bool IsOpenParentheses(char current)
        {
            switch (current)
            {
                case '(':
                case '{':
                case '[':
                    return true;
                default: return false;
            }
        }

        static char MatchParentheses(char current)
        {
            switch (current)
            {
                case ')':
                    return '(';
                case '}':
                    return '{';
                case ']':
                    return '[';
                default: return 'x';
            }
        }
    }
}
