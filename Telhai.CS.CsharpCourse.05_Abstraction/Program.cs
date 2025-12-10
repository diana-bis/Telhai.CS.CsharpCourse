using Telhai.CS.CsharpCourse._05_Abstraction.ClassWorkDrawing;
namespace Telhai.CS.CsharpCourse._05_Abstraction
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

            Drawing rect = new Rectangle();
            Drawing square = new Square();

            List<Drawing> list = new List<Drawing>()
                { rect, square };

            foreach (Drawing shape in list) 
            {
                Console.WriteLine(shape.ToString());
            }

            Dictionary<int, Drawing> dict = new Dictionary<int, Drawing>()
                { { rect.Id, rect}, { square.Id , square} };

            foreach (var shape in dict)
            {
                Console.WriteLine(shape.Value.ToString());
            }
        }
    }
}
