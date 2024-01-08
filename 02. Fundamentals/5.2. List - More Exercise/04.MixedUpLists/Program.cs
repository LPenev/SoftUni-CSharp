namespace _04.MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // input
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            // init vars
            List<int> addedList = new List<int>();
            List<int> resultList = new List<int>();
            List<int> mixedUpList = new List<int>();

            secondList.Reverse();

            if (firstList.Count > secondList.Count)
            {
                resultList.AddRange(firstList.Skip(firstList.Count - 2).Take(2));
                addedList.AddRange(firstList);
                addedList.AddRange(secondList);
            }
            else
            {
                resultList.AddRange(secondList.Skip(secondList.Count - 2).Take(2));
                addedList.AddRange(secondList);
                addedList.AddRange(firstList);
            }

            resultList.Sort();

            foreach (var item in addedList)
            {
                if (item > resultList[0] && item < resultList[1])
                {
                    mixedUpList.Add(item);
                }
            }

            // output
            Console.WriteLine(string.Join(" ", mixedUpList.OrderBy(x => x)));
        }
    }
}
