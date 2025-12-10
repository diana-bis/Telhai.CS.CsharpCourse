using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse.Services.Logging
{
    public enum LogLevel /*public so public func can acess*/
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Exception = 3
    }
    
    /// <summary>
    /// Logger
    /// </summary>
    /// 
    public class Logger
    {
        //Field
        private static Logger instance;
        private string logFilePath;

        private Logger(){}

        private Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public static Logger GetInstance(string path="")
        {
            //First call to instance
            if (Logger.instance == null)
            {
                // one of the ctr will be chosen - not both, but the first one chosen is it
                if (string.IsNullOrEmpty(path))
                {
                    Logger.instance = new Logger();
                }
                else
                {
                    Logger.instance = new Logger(path);
                }
                
            }
            return instance;
        }
        public static Logger Instance
        {
            get
            {
                //First call to instance
                if (Logger.instance == null)
                {
                    Logger.instance = new Logger();
                }
                return instance;
            }
        }

        public static void Log(string message)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine(message + ": " + formattedTime);

        }

        public static void Log(string message, LogLevel level)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string logTxt = $"{message} : {level} : {formattedTime}";
            //Console.WriteLine(message + ": " + level+" "+ formattedTime);
            Console.WriteLine(logTxt);


        }
    }
}
