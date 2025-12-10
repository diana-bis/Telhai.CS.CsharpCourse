using Telhai.CS.CsharpCourse._01_Practice.Logging;
namespace Telhai.CS.CsharpCourse._01_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;
            string osVersion = Environment.OSVersion.ToString();


            Console.WriteLine($"Current User: {userName}");
            Console.WriteLine($"Machine Name: {machineName}");
            Console.WriteLine($"Operating System: {osVersion}");
            Console.WriteLine("-----");

            Console.WriteLine("Hello, World!");
            //Logger logger = new Logger(); since the func was changed to static
            for (int i = 0; i<100; i++)
            {
                //Logger.Log("Running Main " + i);
                if (i % 5 == 0)
                {
                    Logger.Log("Running Main " + i + " "+LogLevel.Debug); //calling the func with the 1 string
                    continue;
                }
                Logger.Log("Running Main " + i);
                    
                
            }


        }
    }
}
