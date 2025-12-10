namespace Telhai.CS.CsharpCourse._03_OOP
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

            PlayList l1 = new PlayList();
            Type type = l1.GetType();
            type.ToString();

            //--We Need Validation Here
            //l1.name = string.Empty;

            l1.Name = "CHIL_OUT";   // Set
            var name_playList = l1.Name;    // Get
            l1.Name += "Playlist";      // Get+Set
            l1.Name = l1.Name + "Playlist";

            // l1.Count = 20; wont work since there is only get, no set

            PlayList l2 = new PlayList();
            l2.Name = "TECHNO";
            l2.Id = 1000;

            PlayList l3 = new PlayList("AMBIENT");

            //--Initializer
            PlayList l4 = new PlayList { Id = 1001, Name = "LOAZI" };

            Console.ReadKey();



        }
    }
}
