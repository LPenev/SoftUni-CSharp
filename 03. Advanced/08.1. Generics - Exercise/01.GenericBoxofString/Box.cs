namespace BoxOfString
{
    public class Box<T>
    {
        private T item;
        
        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            string result = $"{typeof(T)}: {item}";
            return result;
        }
    }
}
