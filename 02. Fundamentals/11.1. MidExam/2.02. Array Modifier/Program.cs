namespace _2._02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();
                if(input == "end")
                {
                    break;
                }
                else if (input == "decrease")
                {
                    for(short i = 0; i < array.Length; i++)
                    {
                        array[i]--;
                    }
                    continue;
                }

                string[] commands = input.Split().ToArray();
                int index1 = int.Parse(commands[1]);
                int index2 = int.Parse(commands[2]);

                if (commands[0] == "swap")
                {
                    int temp = array[index2];
                    array[index2] = array[index1];
                    array[index1] = temp;
                }
                else if (commands[0] == "multiply")
                {
                    array[index1] *= array[index2];
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}