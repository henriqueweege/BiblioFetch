using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.ServicesExceptions
{
    public class SaveNoTrackException : Exception
    {
        public SaveNoTrackException(string message) : base(message) { }
        public SaveNoTrackException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
