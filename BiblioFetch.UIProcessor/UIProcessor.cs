using BiblioFetch.Layout;
using BiblioFetch.UIExceptions;

namespace BiblioFetch.UIProcessor
{
    public static class UIProcessor
    {
        public static List<string> ISBN { get; set; }

        public static void Begin()
        {

            Console.Title = "BiblioFetch";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            InitialRoutine();

        }

        public static void ProcessFile()
        {
            DataReadRoutine();
            Pages.DataBeignProcessed();
            DataProcessRoutine();
        }

        public static void End()
        {
            FinalRoutine();
        }

        private static void FinalRoutine()
        {
            Pages.FinalMessage();
            Thread.Sleep(2000);

            Environment.Exit(1);
        }

        private static void DataProcessRoutine()
        {
            BiblioFetch.ServicesApi.ServicesApi.ProcessData(ISBN);
        }

        private static void DataReadRoutine()
        {
            try
            {
                Pages.InsertFilePath();
                var filePath = Console.ReadLine();
                var reader = DIHandler.GetFileReader();
                ISBN = reader.Read(filePath);

            }
            catch (DataReaderException ex)
            {
                Console.WriteLine(ex.Message);

                Thread.Sleep(2000);
                Console.Clear();
                DataReadRoutine();
            }
        }


        private static void InitialRoutine()
        {
            Pages.Logo();
            Thread.Sleep(1000);
            Console.Clear();
            Pages.WelcomePage();

        }
    }
}