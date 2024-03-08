namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carsDurchGreen = int.Parse(Console.ReadLine());

            var autos = new Queue<string>();
            var input = string.Empty;
            var autosCounter = 0;
            while((input = Console.ReadLine()) != "end")
            {
                if(input == "green")
                {
                    for(int i = 0;i < carsDurchGreen; i++)
                    {
                        if (autos.TryDequeue(out string result))
                        {
                            Console.WriteLine($"{result} passed!");
                            autosCounter++;
                        }
                    }
                }
                else
                {
                    autos.Enqueue(input);
                }
            }
            Console.WriteLine($"{autosCounter} cars passed the crossroads.");
        }
    }
}