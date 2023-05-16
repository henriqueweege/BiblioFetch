using BiblioFetch.Configurations;
using BiblioFetch.DataWriter.Contract;

namespace BiblioFetch.DataWriter
{
    public  class FileWriter : IDataWriter
    {
        public void Write(string content, string? fileName = null)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileName = fileName is null? AppSettings.OutputFileName : fileName;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
            {
                outputFile.WriteLine(content);
            }
        }
    }
}