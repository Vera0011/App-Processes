using System.IO;
using System.Text;

/* IMPORTED FROM ACDA */

namespace ex3
{
    public static class Log_System
    {
        private static string date_start;
        public static void createFile(string fileName)
        {
            try
            {
                File.Create("./src/" + fileName).Dispose();
            }
            catch (Exception error)
            {
                throw;
            }
        }

        public static void writeFile(string input)
        {
            try
            {
                File.AppendAllText("./src/log_" + date_start + ".txt", input);
            }
            catch (Exception error)
            {
                throw;
            }
        }

        public static void Start()
        {
            date_start = DateTime.UtcNow.ToString("yyyyMMddHHmmss").ToString();

            Log_System.createFile("./src/log_" + date_start + ".txt");
        }
    }
}