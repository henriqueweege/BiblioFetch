using BiblioFetch.Configurations;
using BiblioFetch.Models;
using BiblioFetch.Repository;
using BiblioFetch.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace BiblioFetch.ServicesApi
{
    public static class ServicesApi
    {
        private static StringBuilder ToCreateFile { get; set; }

        static ServicesApi()
        {
            ConfigurationHandler.Set();
            ToCreateFile = new StringBuilder();
            ToCreateFile.AppendLine("Row Number, Data Retrival Type, ISBN, Title, Subtitle, AuthorName(s), Number of Pages, Publish Date");

        }


        public static void ProcessData(List<string> isbns)
        {

            GetBooksInfo(isbns, ConfigurationHandler.GetBookRepository());
        }
        public static bool GetBooksInfo(List<string> isbns, [FromServices] IBookRepository bookRepository)
        {
            for (var i = 0; i < isbns.Count(); i++)
            {

                var book = bookRepository.GetByIsbn(isbns[i]);


                if (book is null)
                {
                    book = bookRepository.Save(BiblioFetch.HttpServices.HttpServices.FetchFromServer(isbns[i]));
                }

                AddRow(i + 1, book);

            }

            return true;
        }

        private static void AddRow(int rowNumber, BookModel book)
        {
            var dataRetrievalType = book.FromServer is true ? "Server" : "Cache";
            ToCreateFile.AppendLine($"{rowNumber + 1}, {dataRetrievalType}, {book.ISBN}, {book.Title}, {book.Subtitle}, {book.Authors}, {book.NumberOfPages}, {book.PublishDate}");
        }


    }
}