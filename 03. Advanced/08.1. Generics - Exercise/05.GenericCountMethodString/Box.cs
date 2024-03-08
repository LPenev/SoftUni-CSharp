namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public int CompareToItem(T itemToCompare)
        {
            int count = 0;

            foreach (T item in list)
            {

                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
