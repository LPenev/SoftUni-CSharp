namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int valueA = int.Parse(Console.ReadLine());
                    int valueB = int.Parse(Console.ReadLine());
                    int result = getMax(valueA, valueB);
                    Console.WriteLine(result);
                    break;
                case "char":
                    char charA = char.Parse(Console.ReadLine());
                    char charB = char.Parse(Console.ReadLine());
                    char result_char = getMax(charA, charB);
                    Console.WriteLine(result_char);
                    break;
                case "string":
                    string strA = Console.ReadLine();
                    string strB = Console.ReadLine();
                    string resultString = getMax(strA, strB);
                    Console.WriteLine(resultString);
                    break;
            }
        }

        static int getMax(int valueA, int valueB)
        {
            int result = Math.Max(valueA, valueB);
            return result;
        }

        static char getMax(char valueA, char valueB)
        {
            char result = ' ';

            if(valueA > valueB)
            {
                result = valueA;
            }
            else if(valueA < valueB)
            {
                result = valueB;
            }
            return result;
        }

        static string getMax(string valueA, string valueB)
        {
            string result = null;

            int stringComp = String.Compare(valueA,valueB);
            if(stringComp == 1)
            {
                result = valueA;
            }
            else if(stringComp == -1)
            {
                result = valueB;
            }
            return result;
        }
    }
}
