using BiblioFetch.DataReader.Contract;
using BiblioFetch.UIExceptions;

namespace BiblioFetch.DataReader
{
    public  class FileReader : IDataReader
    {
        public  List<string> Read(string filePath)
        {
            try
            {

                return File
                    .ReadAllText(filePath, System.Text.Encoding.UTF8)
                    .Split(new char[3] { '\n', ',', '\r' })
                    .Where(x => x != "\r" && !String.IsNullOrWhiteSpace(x))
                    .Select(x => x)
                    .ToList();
            }
            catch (FileNotFoundException ex)
            {
                throw new DataReaderException("File could not be found, please, try again.");
            }
            catch (Exception ex)
            {
                throw new DataReaderException("Something went wrong reading the file. Make sure it is in the right format and try again.");
            }
        }
    }
}