using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.DataWriter.Contract
{
    public interface IDataWriter
    {
        void Write(string content, string fileName = null);
    }
}
