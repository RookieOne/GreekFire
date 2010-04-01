using System;

namespace GreekFire.Foundation.ValidationRules
{
    public static class IsRequiredRule
    {
        public static T IsRequired<T>(this T property)
        {
            if (property == null)
                throw new ValidationException("Is Required");

            return property;
        }
    }
}