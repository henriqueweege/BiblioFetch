using BiblioFetch.DataAccess.Contract;
using BiblioFetch.Models;
using BiblioFetch.Repository.Base;
using BiblioFetch.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace BiblioFetch.Repository
{
    public class BookRepository : ReadWriteRepository<BookModel>, IBookRepository
    {

        public IBiblioFetchContext BaseContext { get; set; }
        public DbSet<BookModel> Entity { get; set; }

        public BookRepository(IBiblioFetchContext baseContext):base(baseContext) 
        {
            BaseContext = baseContext;
            Entity = baseContext.Set<BookModel>();
        }

        public BookModel? GetByIsbn(string isbn) => Entity.FirstOrDefault(x => x.ISBN == isbn);

        public override BookModel Save(BookModel model) 
        {
            model.FromServer = false;
            Entity.Add(model);
            BaseContext.SaveChanges();
            model.FromServer = true;

            return model;

        }
    }
}