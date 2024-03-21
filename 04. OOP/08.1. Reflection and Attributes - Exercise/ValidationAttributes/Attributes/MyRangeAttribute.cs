namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int MinValue;
        private int MaxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            bool isValid = (int) obj > MinValue && (int)obj < MaxValue;
            return isValid;
        }
    }
}
