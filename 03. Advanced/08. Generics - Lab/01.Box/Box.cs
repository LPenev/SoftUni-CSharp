namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stack;

        public Box()
        {
            stack = new Stack<T>();
        }

        public void Add(T item)
        {
            stack.Push(item);
        }

        public T Remove()
        {
            return stack.Pop();
        }

        public int Count { get { return stack.Count; } }
    }
}

