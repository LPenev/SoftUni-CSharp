using System.Text;

namespace _03.TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input
            string input = Console.ReadLine();

            // init vars
            List<int> numbers = new List<int>();
            List<string> message = new List<string>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            StringBuilder decryptedMessage = new StringBuilder();
            int index = 0;

            foreach (char ch in input)
            {
                if (char.IsDigit(ch))
                {
                    numbers.Add((int)char.GetNumericValue(ch));
                }
                else
                {
                    message.Add(ch.ToString());
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(message);

                temp = temp.Skip(index).Take(takeList[i]).ToList();
                decryptedMessage.Append(string.Join("", temp));

                index += skipList[i] + takeList[i];
            }

            // output
            Console.WriteLine(decryptedMessage.ToString());
        }
    }
}
