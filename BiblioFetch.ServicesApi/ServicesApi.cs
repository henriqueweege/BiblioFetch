using BiblioFetch.Models;
using BiblioFetch.Repository.Contract;
using BiblioFetch.ServicesExceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BiblioFetch.ServicesApi
{
    public static class ServicesApi
    {

        static ServicesApi()
        {
            DIHandler.Set();
        }

        public static void ProcessData(List<string> isbns)
        {
            var toCreateFile = new StringBuilder();
            toCreateFile.AppendLine("Row Number, Data Retrival Type, ISBN, Title, Subtitle, AuthorName(s), Number of Pages, Publish Date");
            GetBooksInfo(isbns, DIHandler.GetBookRepository(), toCreateFile);

            var writer = DIHandler.GetDataWriter();
            writer.Write(toCreateFile.ToString());
        }

        private static void GetBooksInfo(List<string> isbns, IBookRepository bookRepository, StringBuilder toCreateFile)
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

                    AddRow(i + 1, book, toCreateFile);
                }
                catch (FetchFromServerException ex)
                {
                    AddRow(i + 1, ex.Message, toCreateFile);
                }
                catch (GetByIsbnException ex)
                {
                    AddRow(i + 1, ex.Message, toCreateFile);
                }
                catch (SaveNoTrackException ex)
                {
                    AddRow(i + 1, ex.Message, toCreateFile);
                }
            }
        }
        private static void AddRow(int rowNumber, string message, StringBuilder toCreateFile)
        {

            toCreateFile.AppendLine($"{rowNumber}, {message}, N/A, N/A, N/A, N/A, N/A, N/A");
        }
        private static void AddRow(int rowNumber, BookModel book, StringBuilder toCreateFile)
        {
            string numberPages = book.NumberOfPages > 0 ? book.NumberOfPages.ToString() : "N/A";
            string subtitle = book.Subtitle is not null ? book.Subtitle : "N/A";
            var dataRetrievalType = book.FromServer.ToString();
            toCreateFile.AppendLine($"{rowNumber}, {dataRetrievalType}, {book.ISBN}, {book.Title}, {subtitle}, {book.Authors}, {numberPages}, {book.PublishDate}");
        }
    }
}