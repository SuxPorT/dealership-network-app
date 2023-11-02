namespace DealershipNetworkApp.Infrastructure.Persistence.Utils
{
    public static class ConvertTimeZone
    {
        public static DateTime HrBrasilia(DateTime dateTime)
        {
            var hrBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, hrBrasilia);
        }
    }
}
