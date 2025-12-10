using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telhai.CS.CsharpCourse._05_WpfLinq.Models;

namespace Telhai.CS.CsharpCourse._05_WpfLinq.Services
{
    internal class RandomSongService : ISongService
    {
        private static RandomSongService instance;
        private readonly Random rnd = new Random();     // readonly - these variables can only be assigned once
        private readonly string[] artists =
            {
            "Ed Sheeran",
            "Taylor Swift",
            "Adele",
            "The Weeknd",
            "Bruno Mars",
            "Billie Eilish",
            "Imagine Dragons",
            "Harry Styles",
            "Dua Lipa",
            "Coldplay"
        };
        private readonly string[] titles =
            {
            "Shape of You",
            "Blinding Lights",
            "Someone Like You",
            "Uptown Funk",
            "Bad Guy",
            "Shivers",
            "Levitating",
            "Viva La Vida",
            "As It Was",
            "Perfect"
        };

        // Singleton pattern - to insure random songs, better randomness
        private RandomSongService() { }
        public static RandomSongService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomSongService();
                }
                return instance;
            }
        }

        public List<Song> GenerateSongs(int count)
        {
            var songs = new List<Song>();

            for (int i = 0; i < count; i++)
            {
                var s = new Song
                {
                    Artist = artists[rnd.Next(artists.Length)],     // generates a random integer between 0 and artists.Length - 1
                    Title = titles[rnd.Next(titles.Length)],        // generates a random integer between 0 and titles.Length - 1
                    Duration = Math.Round(rnd.NextDouble() * 8 + 2, 2) // rnd.NextDouble() - gives a random number between 0.0 and 1.0
                };
                songs.Add(s);
            }
            return songs;
        }
    }
}
