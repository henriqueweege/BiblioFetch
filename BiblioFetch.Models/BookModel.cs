using BiblioFetch.Enumerators;

namespace BiblioFetch.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string? Subtitle { get; set; }
        public string Authors { get; set; }
        public int? NumberOfPages { get; set; }
        public string PublishDate { get; set; }
        public EFromServer FromServer { get; set; } = EFromServer.Server;

    }
}