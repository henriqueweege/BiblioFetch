using BiblioFetch.Layout;
using BiblioFetch.Repository;
using BiblioFetch.ServicesApi;
using BiblioFetch.UIFileReaderServices;

namespace BiblioFetch.UIProcessor
{
    public static class UI
    {
        public static List<string> ISBN { get; set; }

        public static void Begin()
        
        {

            Console.Title = "BiblioFetch";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
           
            InitialRoutine();
            FileReadRoutine();
            DataProcessRoutine();
        }

        private static void DataProcessRoutine()
        {
            BiblioFetch.ServicesApi.ServicesApi.ProcessData(ISBN);
        }

        private static void FileReadRoutine()
        {
            try
            {
                Pages.InsertFilePath();
                var filePath = Console.ReadLine();
                ISBN = FileReader.ReadFile(filePath);

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Hum... something went wrong reading your file. Could you try again?");

                Thread.Sleep(5000);
                Console.Clear();
                FileReadRoutine();
            }
        }


        private static void InitialRoutine()
        {
            Pages.Logo();
            Thread.Sleep(3000);
            Console.Clear();
            Pages.WelcomePage();

        }

        public static void Print(string text)
        {
            Console.WriteLine(text);
        }

        public static void ReadFile(string filePath)
        {
            var x = FileReader.ReadFile(filePath);
        }
    }
}