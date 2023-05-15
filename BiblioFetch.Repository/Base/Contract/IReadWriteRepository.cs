using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.Repository.Base.Contract
{
    public interface IReadWriteRepository<T>
    {
        IList<T> GetAll();
        abstract T Save(T entity);
        T Update(T entity);
        T Remove(T entity);
    }
}
