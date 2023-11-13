using System.ComponentModel;
using System.Reflection;

namespace HRIS.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }

        public static TEnum GetEnumValue<TEnum>(this string description)
        {
            Type enumType = typeof(TEnum);

            if (!enumType.IsEnum)
                throw new ArgumentException("The specified type is not an enum.", nameof(TEnum));

            foreach (TEnum value in Enum.GetValues(enumType))
            {
                FieldInfo fieldInfo = enumType.GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0 && attributes[0].Description == description)
                    return value;
            }

            throw new ArgumentException("No matching enum value found for the given description.", nameof(description));
        }
    }
}
