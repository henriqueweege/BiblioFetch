using BiblioFetch.DataAccess.Contract;
using BiblioFetch.Repository.Base.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.Repository.Base
{
    public class ReadWriteRepository<T> : IReadWriteRepository<T>, IDisposable where T : class
    {

        public IBiblioFetchContext BaseContext { get; set; }
        public DbSet<T> Entity { get; set; }

        public ReadWriteRepository(IBiblioFetchContext baseContext)
        {
            BaseContext = baseContext;
            Entity = baseContext.Set<T>();
        }

        public IList<T> GetAll() => Entity.AsNoTracking().ToList();

        public T Remove(T entity) => Entity.Remove(entity).Entity;

        public virtual T SaveNoTrack(T entity) => Entity.Add(entity).Entity;

        public T Update(T entity) => Entity.Update(entity).Entity;

        private int SaveChanges() => BaseContext.SaveChanges();

        public void Dispose()
        {
            SaveChanges();
        }
    }
}
