using HRIS.Domain.Models.Entities;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HRIS.Domain.Extensions
{
    public static class CommonExtension
    {
        public static string ToTitleCase(this string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input);
        }

        public static string GetFullName(this Employee employee) =>
            $"{employee.LastName.ToTitleCase()}, {employee.FirstName.ToTitleCase()}{(string.IsNullOrEmpty(employee.MiddleName) ?
                                                                        string.Empty :
                                                                        ($" {employee.MiddleName.ToTitleCase()[0]}."))}";

        public static string GetFullAddress(this Address address) =>
            $"{address.Line1.ToTitleCase()} {(string.IsNullOrEmpty(address.Line2) ? string.Empty : address.Line2)}, {address.Barangay}, {address.City} {address.Province} {address.ZipCode} {address.Country}";

        public static string RemoveSpecialCharacters(this string? input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Remove spaces and special characters using regex
            string pattern = "[^a-zA-Z0-9]";
            string replacement = "";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(input, replacement);

            return result.ToLower();
        }
    }
}
