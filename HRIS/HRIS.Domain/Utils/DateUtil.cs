namespace HRIS.Domain.Utils
{
    public static class DateUtil
    {
        public static DateTime GetCurrentDate() =>
             TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);

        public static int GetDayDifference(this DateTime inputDateTime, DateTime compareDateTime) =>
            (compareDateTime.Date - inputDateTime.Date).Days;
    }
}
