namespace _05._Character_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            string text = Console.ReadLine();
            int lenght = text.Length;

            for (int i = 0; i < lenght; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
