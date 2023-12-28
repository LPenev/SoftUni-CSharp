using System.Xml.Linq;

namespace _201._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for(int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                
                int startIndexOfName = input.IndexOf("@") + 1;
                int lenghtOfName = input.IndexOf("|") - startIndexOfName;
                string name = input.Substring(startIndexOfName, lenghtOfName);

                int startIndexOfAge = input.IndexOf("#") + 1;
                int lenghtOfAge = input.IndexOf("*") - startIndexOfAge;
                string age = input.Substring(startIndexOfAge, lenghtOfAge);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}