namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string,string>();
            string input = string.Empty;

            while((input = Console.ReadLine()) != "end")
            {
                var charArray = input.ToCharArray();
                Array.Reverse(charArray);
                list.Add(input, String.Concat(charArray));
            }

            foreach (var current in list)
            {
                Console.WriteLine($"{current.Key} = {current.Value}");
            }
        }
    }
}