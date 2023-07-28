namespace _05._Easter_Bake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfEggsInStore = int.Parse(Console.ReadLine());
            
            // init vars
            string command = null;
            int soldEggs = 0;

            while ((command = Console.ReadLine().Trim()) != "Close")
            {
                int eggs = int.Parse(Console.ReadLine());
                
                if (command == "Fill")
                {
                    amountOfEggsInStore += eggs;
                }
                else if(command == "Buy")
                {
                    if (amountOfEggsInStore - eggs < 0)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {amountOfEggsInStore}.");
                        return;
                    }

                    soldEggs += eggs;
                    amountOfEggsInStore -= eggs;
                }
            }


            Console.WriteLine("Store is closed!");
            Console.WriteLine($"{soldEggs} eggs sold.");
        }
    }
}
