using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telhai.CS.CsharpCourse._05_WpfLinq.Models;

namespace Telhai.CS.CsharpCourse._05_WpfLinq.Services
{
    public interface ISongService
    {
        // returns a list of random songs
        List<Song> GenerateSongs(int count);
    }
}
