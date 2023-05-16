using BiblioFetch.Configurations;
using BiblioFetch.Models;
using BiblioFetch.ServicesExceptions;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace BiblioFetch.HttpServices
{
    public static class HttpServices
    {
        public static BookModel FetchFromServer(string isbn)
        {
            try
            {

                String url = $"{AppSettings.ApiUrlRoot}{isbn}{AppSettings.ApiUrlParameters}";
                String json = new WebClient().DownloadString(url);

                JObject jsonObject = JObject.Parse(json);
                JToken details = jsonObject.SelectToken("ISBN:" + isbn);

                return new BookModel()
                {
                    ISBN = isbn,
                    Title = (string)details["title"],
                    Subtitle = details["subtitle"] is null ? null : (string)details["subtitle"],
                    Authors = GetAuthors(details).ToString(),
                    NumberOfPages = details["number_of_pages"] is null ? 0 : (int)details["number_of_pages"],
                    PublishDate = (string)details["publish_date"]
                };
            }
            catch
            {
                throw new FetchFromServerException("Error occured when trying to fetch from server.");
            }
        }



        private static StringBuilder GetAuthors(JToken details)
        {
                var authors = new StringBuilder();

                foreach (var v in details["authors"])
                {
                    authors.Append($"{v["name"].ToString()}; ");
                }

                return authors;
        }
    }
}