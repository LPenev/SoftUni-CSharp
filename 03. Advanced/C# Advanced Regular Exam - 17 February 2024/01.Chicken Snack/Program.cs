namespace _01.Chicken_Snack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> amountOfMoney = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> prices = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int eatCounter = 0;
            int restOfMoney = 0;

            while(amountOfMoney.Count > 0 && prices.Count > 0)
            {
                int currentMoney = amountOfMoney.Pop();
                int price = prices.Dequeue();

                if(currentMoney + restOfMoney == price)
                {
                    eatCounter++;
                }
                else if(currentMoney + restOfMoney > price)
                {
                    eatCounter++;
                    restOfMoney = currentMoney + restOfMoney - price;

                }
            }

            if(eatCounter >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {eatCounter} foods.");
            }
            else if(eatCounter > 1)
            {
                Console.WriteLine($"Henry ate: {eatCounter} foods.");
            }
            else if (eatCounter == 1)
            {
                Console.WriteLine($"Henry ate: {eatCounter} food.");
            }
            else
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}
