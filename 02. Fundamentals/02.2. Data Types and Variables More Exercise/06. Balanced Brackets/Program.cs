
int numberOfLines = int.Parse(Console.ReadLine());
bool isBalanced = true;
bool isOpen = false;

for (int i = 0; i < numberOfLines; i++)
{
    string input = Console.ReadLine();
    if(input.Length > 1)
    {
        continue;
    }
    else if (input[0] == '(' && isOpen)
    {
        isBalanced = false;
        break;
    }
    else if (input[0] == '(')
    {
        isOpen = true;
        isBalanced = false;
    }
    else if (input[0] == ')' && isOpen)
    {
        isOpen = false;
        isBalanced = true;
    }
    else if (input[0] == ')')
    {
        isBalanced=false;
        break;
    }
}

// print result
if(isBalanced)
{
    Console.WriteLine("BALANCED");
}
else
{
    Console.WriteLine("UNBALANCED");
}

