using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.ServicesExceptions
{
    public class GetByIsbnException : Exception
    {
        public GetByIsbnException(string message) : base(message) { }
        public GetByIsbnException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
