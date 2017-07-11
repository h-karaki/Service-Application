using ServiceApplication.Interfaces;

namespace ServiceApplication.Modules
{
    static class Logger
    {
        public static void StartLog()
        {
            System.IO.File.AppendAllText("log.txt", "\r\n" + System.DateTime.Today +" - " + System.DateTime.Now + "\r\n");
            System.IO.File.AppendAllText("log.txt", "=========================================\r\n");
        }

        public static void PrintToLog(string data)
        {
            System.IO.File.AppendAllText("log.txt", data + "\r\n");
        }
    }
}
