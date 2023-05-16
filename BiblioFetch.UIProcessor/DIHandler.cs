using BiblioFetch.DataReader;
using BiblioFetch.DataReader.Contract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BiblioFetch.UIProcessor
{
    public static class DIHandler
    {
        private static IHost _Host { get; set; }

        public static void Set()
        {
            _Host = Host.CreateDefaultBuilder()
                 .ConfigureServices(services =>
                 {
                     services.AddSingleton<IDataReader, FileReader>();
                 })
                 .Build();
        }


        public static IDataReader GetFileReader() => (IDataReader)_Host.Services.GetService(typeof(IDataReader));

    }
}
