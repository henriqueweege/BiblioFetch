using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFetch.Layout
{
    public static class Pages
    {
        public static void Logo()
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(" ─────────────────────────────────────────────────────────────────────────────────                    \n" +
                          "|    ___   |     ____    |    ___   |     ____    |   |    |   |    |        |   |             \n" +
                          "|   |__/   |    |___/    |   |__/   |    |___/    |   |    |   |    |   _____|   |             \n" +
                          "|          |             |          /             |   |    |   |    |   |__  |   |              \n" +
                          "|  ────────|    ──────   |    __   /|    ──────   |   |    |   |    |    __| |   |              \n" +
                          "|   |      |   |     |   |   |  \\  \\|   |     |   |   |    |   |    |   |    |   |             \n" +
                          "|   |      |   |     |   |   |  |   |   |     |   |   |____|   |____|   |____|   |____                   \n" +
                          "|   |      |   |     |   |   |  |   |   |     |   |        |        |        |        |                  \n" +
                          "|___|      |___|     |___|___|  |___|___|     |___|________|________|________|________|                          \n");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Console.Write("                                             ────────────────────────────────────────────────────────  \n" +
                          "                                            |           |           |     ____    |        |        |  \n" +
                          "                                            |   ________|____   ____|    |___/    |  ______|  ______|  \n" +
                          "                                            |   |           |   |   |             |  |____ |  |____    \n" +
                          "                                            |   |_______    |   |   |    ──────   |       ||       |   \n" +
                          "                                            |______     |   |   |   |   |     |   |   ____||   ____|   \n" +
                          "                                             ______|    |   |   |   |   |     |   |   |    |   |       \n" +
                          "                                            |           |   |   |   |   |     |   |   |    |   |       \n" +
                          "                                            |___________|   |___|   |___|     |___|___|    |___|       \n");


        }

        public static void WelcomePage()
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to BiblioFetch!!");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void InsertFilePath()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please, insert the path to the file you want to utilize...");
        }

        public static void FinalMessage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your data was processed. Please, check the outputfile in MyDocuments folder.");
            Console.WriteLine("Thank you for using BiblioFetch.");
        }

        public static void DataBeignProcessed() 
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your file is being processed.");
        }
    }
}
