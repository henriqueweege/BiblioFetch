using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.DataAccess.Contract
{
    public interface IBiblioFetchContext
    {
        EntityEntry Entry(Object entity);
        DbSet<T> Set<T>() where T : class;
        Int32 SaveChanges();
    }
}
