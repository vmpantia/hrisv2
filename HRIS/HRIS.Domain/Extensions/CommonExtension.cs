using System.Globalization;

namespace HRIS.Domain.Extensions
{
    public static class CommonExtension
    {
        public static string ToTitleCase(this string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input);
        }
    }
}
