using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telhai.CS.CsharpCourse.Services.Logging;

namespace Telhai.CS.CsharpCourse._03_OOP
{
    public class PlayList
    {
        private List<string> songs;
        private string name;
        //private int count; - no need //Size of playlist

        //Empty Ctor
        public PlayList() : this("No Name")
        {
            //name = "No Name";
            Logger.Log("In Empty Ctor", LogLevel.Debug);
            
        }

        public PlayList(string name)
        {
            // --No property with setter, go to field (no validation)
            //this.name = name; 
            Name = name;    //set
            songs = new List<string>();
        }


        //Getter + setter
        public string Name
        {
            get { return name.ToUpper(); }    // return this.name
            set { 
                if (string.IsNullOrEmpty(value))
                {
                    name = "<NO PLAYLIST NAME>";
                }
                name = value;  
            }    // val מילה שמורה

        }
        /// <summary>
        /// מייצר מאחורי הקלאים שדה id
        /// Auto proprties
        /// </summary>
        public int Id { get; set; }
        public int MyProperty { get; set; }

        /// <summary>
        /// Get the count of the songs
        /// </summary>
        public int Count
        {
            //get { return songs.Count; }
            get => songs.Count; 
        }

        //public int Count => songs.Count;
    }
}
