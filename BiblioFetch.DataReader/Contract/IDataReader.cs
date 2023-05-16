using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.DataReader.Contract
{
    public interface IDataReader
    {
        public List<string> Read(string path);
    }
}
