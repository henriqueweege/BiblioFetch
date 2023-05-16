using System.ComponentModel;

namespace BiblioFetch.Enumerators
{
    public enum EFromServer
    {
        [Description("Cache")]
        Cache = 0,
        [Description("Server")]
        Server = 1
    }
}