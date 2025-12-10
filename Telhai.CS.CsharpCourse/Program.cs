//01 Using for other Namespace
using Telhai.CS.CsharpCourse.Database;
namespace Telhai.CS.CsharpCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //02 Use only class name
            Db d = new Db();
            //03 No need to add namespace
            FileManager filemanager = new FileManager();
            Console.ReadKey();
        }
    }
}
