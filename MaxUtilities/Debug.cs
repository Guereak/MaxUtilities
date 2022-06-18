using System;
using System.IO;

namespace MaxUtilities
{
    public class Debug
    {
        static bool logExists = false;

        public static void LogOnly(object obj)
        {
            if (!logExists)
                CreateLog();

            if (obj is null)
                return;
            string ret = obj.ToString();
            DateTime now = DateTime.Now;
            string time = now.ToString("[HH:mm:ss]  ");
            try
            {
                using (StreamWriter sw = File.AppendText("debug.log"))
                {
                    sw.WriteLine(time + "LOG: " + ret);
                }
            }
            catch (IOException)
            {
                Log(ret);
            }
        }

        public static void Log(object obj)
        {
            if (!logExists)
                CreateLog();

            if (obj is null)
                return;

            string ret = obj.ToString();
            DateTime now = DateTime.Now;
            string time = now.ToString("[HH:mm:ss] ");
            try
            {
                using (StreamWriter sw = File.AppendText("debug.log"))
                {
                    sw.WriteLine(time + ret);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(time + ret);
            }
            catch (IOException)
            {
                Log(ret);
            }
        }

        public static void LogWarning(object obj)
        {
            if (!logExists)
                CreateLog();

            if (obj is null)
                return;

            string ret = obj.ToString();
            DateTime now = DateTime.Now;
            string time = now.ToString("[HH:mm:ss]  ");
            try
            {
                using (StreamWriter sw = File.AppendText("debug.log"))
                {
                    sw.WriteLine(time + "WARNING: " + ret);
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(time + ret);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (IOException)
            {
                LogWarning(ret);
            }
        }

        public static void LogError(object obj)
        {
            if (!logExists)
                CreateLog();

            if (obj is null)
                return;

            string ret = obj.ToString();
            DateTime now = DateTime.Now;
            string time = now.ToString("[HH:mm:ss]  ");
            try
            {
                using (StreamWriter sw = File.AppendText("debug.log"))
                {
                    sw.WriteLine(time + "ERROR: " + ret);
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(time + ret);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (IOException)
            {
                LogError(ret);
            }
        }

        public static void ClearLog()
        {
            if (!logExists)
                CreateLog();

            using (FileStream fs = File.Open("debug.log", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
            }
        }

        private static void CreateLog()
        {
            if(!File.Exists("debug.log"))
                File.Create("debug.log");

            logExists = true;
        }
    }
}
