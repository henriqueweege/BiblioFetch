using BiblioFetch.DataWriter;

namespace BiblioFetch.FileWriterUnitTests
{
    public class FileWriterTests
    {
        [Fact]
        public void Write_ShouldWriteContentToFile()
        {
            // arrange
            var content = "Content";
            var name = "testfile.txt";
            var completePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
            var writer = new FileWriter();

            //act
            writer.Write(content, name);

            //assert
            var contentFromFile = File.ReadAllText(completePath, System.Text.Encoding.UTF8);
            Assert.Equal(content, contentFromFile.Split(new char[1] { '\r' })[0]);
            File.Delete(completePath);

        }
    }
}