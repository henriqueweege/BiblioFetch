using Microsoft.Extensions.Configuration;


namespace BiblioFetch.Configurations
{
    public static class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string ApiUrlRoot { get; set; }
        public static string ApiUrlParameters { get; set; }
        public static string PathToCreateFile { get; set; }

    }
}