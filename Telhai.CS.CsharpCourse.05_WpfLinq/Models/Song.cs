using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse._05_WpfLinq.Models
{
    public class Song
    {
        public string Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public double Duration { get; set; }

        public Song()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Id} | {Artist} - {Title} | {Duration:F1} min";
        }
    }
}
