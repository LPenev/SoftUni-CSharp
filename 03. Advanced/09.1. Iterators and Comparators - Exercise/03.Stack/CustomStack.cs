using System.Collections;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public CustomStack()
        {
            Items = new List<T>();
            Counter = 0;
        }

        private List<T> Items { get; set; }
        public int Counter { get; private set; }

        public void Push(T value)
        {
            Items.Add(value);
            Counter++;
        }

        public T Pop()
        {
            T value = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            Counter--;
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                yield return Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}