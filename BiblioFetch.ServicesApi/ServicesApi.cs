using BiblioFetch.Models;
using BiblioFetch.Repository.Contract;
using BiblioFetch.ServicesExceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BiblioFetch.ServicesApi
{
    public static class ServicesApi
    {
        private static StringBuilder ToCreateFile { get; set; }

        static ServicesApi()
        {
            DIHandler.Set();
            ToCreateFile = new StringBuilder();
            ToCreateFile.AppendLine("Row Number, Data Retrival Type, ISBN, Title, Subtitle, AuthorName(s), Number of Pages, Publish Date");
        }


        public static void ProcessData(List<string> isbns)
        {
            GetBooksInfo(isbns, DIHandler.GetBookRepository());

            var writer = DIHandler.GetDataWriter();
            writer.Write(ToCreateFile.ToString());
        }

        private static void GetBooksInfo(List<string> isbns, IBookRepository bookRepository)
        {
            for (var i = 0; i < isbns.Count(); i++)
            {
                try
                {
                    var book = bookRepository.GetByIsbn(isbns[i]);

                    if (book is null)
                    {
                        book = BiblioFetch.HttpServices.HttpServices.FetchFromServer(isbns[i]);
                        bookRepository.SaveNoTrack(book);
                        book.FromServer = Enumerators.EFromServer.Server;
                    }

                    AddRow(i + 1, book);
                }
                catch (FetchFromServerException ex)
                {
                    AddRow(i + 1, ex.Message);
                }
                catch (GetByIsbnException ex)
                {
                    AddRow(i + 1, ex.Message);
                }
                catch (SaveNoTrackException ex)
                {
                    AddRow(i + 1, ex.Message);
                }
            }
        }
        private static void AddRow(int rowNumber, string message)
        {

            ToCreateFile.AppendLine($"{rowNumber}, {message}, N/A, N/A, N/A, N/A, N/A, N/A");
        }
        private static void AddRow(int rowNumber, BookModel book)
        {
            string numberPages = book.NumberOfPages > 0 ? book.NumberOfPages.ToString() : "N/A";
            string subtitle = book.Subtitle is not null ? book.Subtitle : "N/A";
            var dataRetrievalType = book.FromServer.ToString();
            ToCreateFile.AppendLine($"{rowNumber}, {dataRetrievalType}, {book.ISBN}, {book.Title}, {subtitle}, {book.Authors}, {numberPages}, {book.PublishDate}");
        }
    }
}