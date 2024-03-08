namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> inputedRange)
        {
            foreach (var item in inputedRange)
            {
                this.Push(item);
            }
        }

    }
}
