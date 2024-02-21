namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("11");
            list.Add("22");
            list.Add("33");
            list.Add("44");
            list.Add("55");

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());

            list.RemoveRandomElement();
            list.RemoveRandomElement();

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());

        }
    }
}
