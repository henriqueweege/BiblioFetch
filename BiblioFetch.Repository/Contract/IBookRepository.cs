using BiblioFetch.Models;
using BiblioFetch.Repository.Base.Contract;
using System.Runtime.CompilerServices;

namespace BiblioFetch.Repository.Contract
{
    public interface IBookRepository : IReadWriteRepository<BookModel>
    {
        public BookModel? GetByIsbn(string isbn);

        public BookModel Save(BookModel model);
    }
}
