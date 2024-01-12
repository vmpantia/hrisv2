namespace HRIS.Domain.Utils
{
    public static class DateUtil
    {
        public static DateTime GetCurrentDate() =>
             TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);

        public static int GetDayDiff(this DateTime inputDateTime, DateTime compareDateTime) =>
            (compareDateTime.Date - inputDateTime.Date).Days;

        public static int GetYearDiff(this DateTime inputDateTime, DateTime compareDateTime) =>
            compareDateTime.Date.Year - inputDateTime.Date.Year;
    }
}
