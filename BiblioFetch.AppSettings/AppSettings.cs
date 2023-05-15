using Microsoft.Extensions.Configuration;

namespace BiblioFetch.Configurations
{
    public static class AppSettings
    {
        private static IConfiguration Configuration { get; set; }
        public static string ConnectionString { get; set; }
        public static string ApiUrlRoot { get; set; }
        public static string ApiUrlParameters { get; set; }
        public static string PathToCreateFile { get; set; }
        static AppSettings()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                              .Build();
            SetAppSettings();
        }

        private static void SetAppSettings()
        {
            ConnectionString = Configuration.GetSection("ConnectionString").Value;
            ApiUrlRoot = Configuration.GetSection("ApiUrlRoot").Value;
            ApiUrlParameters = Configuration.GetSection("ApiUrlParameters").Value;
            PathToCreateFile = Configuration.GetSection("PathToCreateFile").Value;
        }
    }
}