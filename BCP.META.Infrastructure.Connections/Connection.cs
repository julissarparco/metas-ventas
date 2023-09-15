using BCP.META.Crosscuting.Helper;

namespace BCP.META.Infrastructure.Connections
{
    public static class Connection
    {
        public static string GetConnectionString()
        {
            AppSettingHelper appSettingHelper = new();
            string connectionString = appSettingHelper.ConnectionString;
            return connectionString;
        }
    }
}