namespace BiblioFetch.UIFileReaderServices
{
    public static class FileReader
    {
        public static List<string> ReadFile(string filePath)
        {
            return File
                .ReadAllText(filePath, System.Text.Encoding.UTF8)
                .Split(new char[3] { '\n', ',', '\r' })
                .Where(x => x != "\r" && !String.IsNullOrWhiteSpace(x))
                .Select(x=>x)
                .ToList();
        }
    }
}