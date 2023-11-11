namespace _105._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputCharArray = Console.ReadLine()
                .TrimStart('0')
                .ToCharArray()
                .Select(x => int.Parse(x.ToString()))
                .Reverse()
                .ToArray();

            int multiplayer = int.Parse(Console.ReadLine());
            int remainder = 0;
            var resutList = new List<int>();

            if (multiplayer == 0)
            {
                Console.WriteLine("0");
                return;
            }

            foreach (int digit in inputCharArray)
            {
                int result = digit * multiplayer + remainder;
                
                remainder = result / 10;
                result %= 10;

                resutList.Add(result);
            }

            if(remainder > 0)
            {
                resutList.Add(remainder);
            }

            resutList.Reverse();
            Console.WriteLine(string.Join(string.Empty, resutList));
        }
    }
}