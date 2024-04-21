namespace _103._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfguests = int.Parse(Console.ReadLine());
            List<string> listOfGuests = new List<string>();

            for(int i = 0; i < countOfguests; i++)
            {
                string input = Console.ReadLine();
                string[] inputArray = input.Split().ToArray();

                if (input.EndsWith("is going!"))
                {
                    AddGuest(listOfGuests, inputArray[0]);
                }
                else if (input.EndsWith("is not going!"))
                {
                    DeleteGuest(listOfGuests, inputArray[0]);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, listOfGuests));
        }

        static void AddGuest(List<string> listOfGuests,string guest)
        {
            if (listOfGuests.IndexOf(guest) == -1)
            {
                listOfGuests.Add(guest);
            }
            else
            {
                Console.WriteLine("{0} is already in the list!", guest);
            }
        }

        static void DeleteGuest(List<string> listOfGuests, string guest)
        {
            if (listOfGuests.IndexOf(guest) != -1)
            {
                listOfGuests.Remove(guest);
            }
            else
            {
                Console.WriteLine("{0} is not in the list!", guest);
            }
        }
    }
}