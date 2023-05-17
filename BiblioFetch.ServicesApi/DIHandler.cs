using BiblioFetch.Configurations;
using BiblioFetch.DataAccess;
using BiblioFetch.DataAccess.Contract;
using BiblioFetch.DataWriter;
using BiblioFetch.DataWriter.Contract;
using BiblioFetch.Repository;
using BiblioFetch.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BiblioFetch.ServicesApi
{
    public static class DIHandler
    {
        private static IHost _Host { get; set; }

        public static void Set()
        {
            _Host = Host.CreateDefaultBuilder()
                 .ConfigureServices(services =>
                 {
                     services.AddSingleton<IBookRepository, BookRepository>();
                     services.AddTransient<IBiblioFetchContext, BiblioFetchContext>();
                     services.AddTransient<DbContextOptionsBuilder>();
                     services.AddSingleton<IDataWriter, FileWriter>();
                 })
                 .Build();

            AppSettings.Set();
        }


        public static IBookRepository GetBookRepository() => (IBookRepository)_Host.Services.GetService(typeof(IBookRepository));
        public static IDataWriter GetDataWriter() => (IDataWriter)_Host.Services.GetService(typeof(IDataWriter));

    }
}
