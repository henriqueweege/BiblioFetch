namespace BiblioFetch.UIExceptions
{
    public class DataReaderException : Exception
    {
        public DataReaderException(string message) : base(message) { }
        public DataReaderException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}