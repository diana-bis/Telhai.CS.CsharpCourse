using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse._01_Practice.Logging
{
    public enum LogLevel /*public so public func can acess*/
    {
        Debug=0,
        Info=1,
        Warn=2,
        Exception=3
    }
    public class Logger
    {
        public static void Log(string message)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine(message+": "+ formattedTime);

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
