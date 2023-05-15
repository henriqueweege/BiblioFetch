using BiblioFetch.DataAccess;
using BiblioFetch.DataAccess.Contract;
using BiblioFetch.Repository;
using BiblioFetch.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BiblioFetch.Configurations
{
    public static class ConfigurationHandler
    {
        private static IHost Config { get; set; }

        static ConfigurationHandler()
        {
            
        }
        public static void Set()
        {

            AddDependencies();
        }


        private static void AddDependencies()
        {
            Config = Host.CreateDefaultBuilder()
                 .ConfigureServices(services =>
                 {
                     services.AddTransient<IBookRepository, BookRepository>();
                     services.AddTransient<IBiblioFetchContext, BiblioFetchContext>();
                     services.AddTransient<DbContextOptionsBuilder>();
                 })
                 .Build();
        }

        public static BookRepository GetBookRepository() => (BookRepository)Config.Services.GetService(typeof(IBookRepository));
        

    }
}
