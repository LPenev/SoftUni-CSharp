using System;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            bool result = obj is not null;
           return result;
        }
    }
}
