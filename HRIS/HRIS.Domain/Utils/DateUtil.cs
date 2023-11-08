namespace HRIS.Domain.Utils
{
    public class DateUtil
    {
        public static DateTime GetCurrentDate() =>
             TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
    }
}
