using System.Text;

namespace GenericSwapMethodString
{
    public class Box<T>
    {
        private List<T> list;

        public Box(List<T> listItems, int indexA, int indexB)
        {
            this.list = listItems;
            // swap index two indexes
            T current = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = current;
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
