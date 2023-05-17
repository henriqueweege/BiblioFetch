using BiblioFetch.DataAccess.Contract;
using BiblioFetch.Models;
using BiblioFetch.Repository.Base;
using BiblioFetch.Repository.Contract;
using BiblioFetch.ServicesExceptions;
using Microsoft.EntityFrameworkCore;

namespace BiblioFetch.Repository
{
    public class BookRepository : ReadWriteRepository<BookModel>, IBookRepository
    {

        public IBiblioFetchContext BaseContext { get; set; }
        public DbSet<BookModel> Entity { get; set; }

        private List<BookModel> BooksCache { get; set; } = new List<BookModel>();


        public BookRepository(IBiblioFetchContext baseContext) : base(baseContext)
        {
            BaseContext = baseContext;
            Entity = baseContext.Set<BookModel>();
        }

        internal BookModel? GetByIsbnFromDb(string isbn) => Entity.AsNoTracking().FirstOrDefault(x => x.ISBN == isbn);


        public BookModel? GetByIsbn(string isbn)
        {
            try
            {
                BookModel? book = null;

                if(BooksCache.Count > 0)
                {
                    book = BooksCache.FirstOrDefault(e => e.ISBN == isbn);
                    if (book is not null)  book.FromServer = Enumerators.EFromServer.Cache;
                }

                if (book is null)
                {
                    book = GetByIsbnFromDb(isbn);
                    if (book is not null)
                    {
                        book.FromServer = Enumerators.EFromServer.Cache;
                        BooksCache.Add(book);
                    }
                }

                return book;
            }
            catch
            {
                throw new GetByIsbnException("Something went wrong retrieving book data.");
            }
        }

        public void SaveNoTrack(BookModel book)
        {
            try
            {

                Entity.AsNoTracking();
                book.FromServer = Enumerators.EFromServer.Cache;
                Entity.Add(book);
                BooksCache.Add(book);
                BaseContext.SaveChanges();
            }
            catch
            {
                throw new SaveNoTrackException("Something went wrong saving book data.");
            }
        }
    }
}