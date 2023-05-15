using BiblioFetch.HttpServices;

namespace BiblioFetch.HttpServicesUnitTests
{
    public class FetchFromServerUnitTests
    {
        [Fact]
        public void GivenValidISBN_SouldReturnValidObject()
        {
            //arrange

            var isbn = "0201558025";

            //act
            var response = BiblioFetch.HttpServices.HttpServices.FetchFromServer(isbn);

            //assert
            Assert.Equal(isbn,response.ISBN);
            Assert.Equal(657, response.NumberOfPages);
            Assert.Equal(true, response.FromServer);
            Assert.Equal("Ronald L. Graham; Donald Knuth; Oren Patashnik; ", response.Authors);
            Assert.Equal("1994", response.PublishDate);
            Assert.Equal("Concrete mathematics", response.Title);
            Assert.Equal("a foundation for computer science", response.Subtitle);
        }
    }
}