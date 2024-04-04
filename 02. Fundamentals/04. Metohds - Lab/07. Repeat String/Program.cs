namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputedString = Console.ReadLine();
            int timesRepeat = int.Parse(Console.ReadLine());
            string textToPring = repeatString(inputedString, timesRepeat);
            Console.WriteLine(textToPring);
        }

        static string repeatString(string text, int timeOfRepeat)
        {
            string result = "";
            for(int i = 1;i <= timeOfRepeat;i++)
            {
                result += text;
            }
            return result;
        }
    }
}