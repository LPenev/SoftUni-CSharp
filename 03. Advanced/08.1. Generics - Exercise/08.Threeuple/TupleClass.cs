﻿namespace Threeuple
{
    public class TupleClass<T1, T2, T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }

        public TupleClass(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public override string ToString()
        {
            string result = $"{Item1} -> {Item2} -> {Item3}";
            return result;
        }
    }
}
