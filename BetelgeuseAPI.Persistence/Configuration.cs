using Microsoft.Extensions.Configuration;

namespace BetelgeuseAPI.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

                string connectionString = configuration.GetConnectionString("PostgreSQL")!;
                return connectionString;
            }
        }
    }
}
