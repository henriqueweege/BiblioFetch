using BiblioFetch.Models;
using BiblioFetch.Repository.Base.Contract;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace BiblioFetch.Repository.Contract
{
    public interface IBookRepository : IReadWriteRepository<BookModel>
    {
        public BookModel? GetByIsbn(string isbn);
        public void SaveNoTrack(BookModel model);
    }
}
