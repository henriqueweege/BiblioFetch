using Microsoft.Extensions.Configuration;

namespace BiblioFetch.Configurations
{
    public static class AppSettings
    {
        private static IConfiguration Configuration { get; set; }
        public static string ConnectionString { get; set; }
        public static string ApiUrlRoot { get; set; }
        public static string ApiUrlParameters { get; set; }
        public static string OutputFileName { get; set; }
        public static bool InMemoryDb { get; set; }

        static AppSettings()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                              .Build();
            SetAppSettings();
        }
        public static void Set() { }
        private static void SetAppSettings()
        {
            ConnectionString = Configuration.GetSection("ConnectionString").Value;
            ApiUrlRoot = Configuration.GetSection("ApiUrlRoot").Value;
            ApiUrlParameters = Configuration.GetSection("ApiUrlParameters").Value;
            OutputFileName = Configuration.GetSection("OutputFileName").Value;
            InMemoryDb = Convert.ToBoolean(Configuration.GetSection("InMemoryDb").Value);
        }
    }
}