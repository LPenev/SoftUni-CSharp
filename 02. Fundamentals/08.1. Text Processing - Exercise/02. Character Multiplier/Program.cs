namespace _102._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(Multiply(input[0], input[1]));
        }

        public static int Multiply(string str1, string str2)
        {
            var result = 0;
            if(str2.Length > str1.Length)
            {
                var temp = str1;
                str1 = str2;
                str2 = temp;
            }

            for(var i = 0;i < str1.Length; i++)
            {
                if (str2.Length <= i )
                {
                    result += (int)str1[i];
                    continue;
                }
                int a = (int)str1[i];
                int b = (int)str2[i];
                result += a * b;
            }

            return result;
        }
    }
}