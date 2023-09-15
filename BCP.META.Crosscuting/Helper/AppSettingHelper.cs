using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace BCP.META.Crosscuting.Helper
{
    [ExcludeFromCodeCoverage]
    public class AppSettingHelper
    {
        public AppSettingHelper() {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            var configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(baseDirectory)
                 .AddJsonFile(path, false, true);

            IConfigurationRoot root = configurationBuilder.Build();

            ConnectionString = root.GetConnectionString("BD_BCP");
        }

        public string ConnectionString { get; }
    }
}
