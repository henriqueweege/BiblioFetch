using BiblioFetch.DataReader;

namespace BiblioFetch.FileReaderUnitTest
{
    public class FileReaderTests
    {
        [Fact]
        public void Read_ShouldReadContentFromFile()
        {
            //arrante
            var content = "test";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var name = "testFile.txt";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, name)))
            {
                outputFile.WriteLine(content);
            }
            var completePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
            var reader = new FileReader();

            //act
            var contentFromFile = reader.Read(completePath)[0];

            //assert
            Assert.Equal(content, contentFromFile);
            File.Delete(completePath);
        }
    }
}