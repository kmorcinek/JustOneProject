using System;

namespace JustOneProject.Extensions
{
    public class EnumHelper
    {
        public static TEnum GetEnumFromString<TEnum>(string value) where TEnum : struct, IComparable
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException(string.Format("{0} must be an enumerated type", typeof(TEnum).FullName));
            }

            return (TEnum)Enum.Parse(typeof(TEnum), value, true);
        }
    }
}