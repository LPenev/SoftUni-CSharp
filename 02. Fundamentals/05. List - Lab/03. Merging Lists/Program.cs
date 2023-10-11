namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> input2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = MergeTwoList(input1,input2);
            
            Console.WriteLine(string.Join(" ",result));

        }

        static List<int> MergeTwoList(List<int> input1, List<int> input2)
        {
            List<int> result = new List<int>();
            int counter = 0;

            int endPoint = Math.Min(input1.Count, input2.Count);

            for(int i = 0;i < endPoint; i++)
            {
                result.Add(input1[i]);
                result.Add(input2[i]);
            }

            if(input1.Count > input2.Count)
            {
                for(int i = endPoint; i < input1.Count; i++)
                {
                    result.Add(input1[i]);
                }
            }
            else if (input2.Count > input1.Count)
            {
                for(int i = endPoint; i < input2.Count; i++)
                {
                    result.Add(input2[i]);
                }
            }
            
            return result;
        }

    }
}