namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private readonly Random rnd;
        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            int index = rnd.Next(0, this.Count);
            return this[index];
        }

        public string RemoveRandomElement()
        {
            int index = rnd.Next(0, this.Count);
            string currentStr = this[index];
            this.RemoveAt(index);
            return currentStr;
        }
    }
}
