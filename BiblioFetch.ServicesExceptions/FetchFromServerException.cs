namespace BiblioFetch.ServicesExceptions
{
    public class FetchFromServerException : Exception
    {
        public FetchFromServerException(string message) : base(message) { }
        public FetchFromServerException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}