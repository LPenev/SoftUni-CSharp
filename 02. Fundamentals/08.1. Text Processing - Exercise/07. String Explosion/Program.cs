namespace _107._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                }
                else if (strength > 0)
                {
                    input = input.Remove(i, 1);
                    strength--;
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}