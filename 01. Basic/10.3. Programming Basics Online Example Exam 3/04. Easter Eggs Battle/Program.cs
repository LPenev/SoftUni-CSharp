namespace _04._Easter_Eggs_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from Console 
            int numberOfEggsFirstPlayer = int.Parse(Console.ReadLine());
            int numberOfEggsSecondPlayer = int.Parse(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine().Trim()) != "End")
            {


                if (input == "one")
                {
                    numberOfEggsSecondPlayer--;
                }
                else if (input == "two")
                {
                    numberOfEggsFirstPlayer--;
                }

                if (numberOfEggsFirstPlayer < 1)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {numberOfEggsSecondPlayer} eggs left.");
                    return;
                }
                else if (numberOfEggsSecondPlayer < 1)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {numberOfEggsFirstPlayer} eggs left.");
                    return;
                }
            }

            Console.WriteLine($"Player one has {numberOfEggsFirstPlayer} eggs left.");
            Console.WriteLine($"Player two has {numberOfEggsSecondPlayer} eggs left.");
        }
    }
}
