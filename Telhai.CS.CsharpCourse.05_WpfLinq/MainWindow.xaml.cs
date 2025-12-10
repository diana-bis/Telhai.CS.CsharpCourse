using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telhai.CS.CsharpCourse._05_WpfLinq.Models;
using Telhai.CS.CsharpCourse._05_WpfLinq.Services;

namespace Telhai.CS.CsharpCourse._05_WpfLinq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// Student name: Diana Bistrik
    /// ID: 324091818
    /// 
    public partial class MainWindow : Window
    {
        private List<Song> songsList = new List<Song>();  // store current songs

        public MainWindow()
        {
            InitializeComponent();

            // Initialize placeholders
            SetPlaceholder(txtArtist, "Artist");
            SetPlaceholder(txtTitle, "Title");
            SetPlaceholder(txtDuration, "Duration (1–10)");
            SetPlaceholder(txtSearch, "Search song");

            this.songsListBox.SelectionChanged += SongsListBox_SelectionChanged;

        }

        private void SetPlaceholder(TextBox box, string placeholder)
        {
            // show placeholder initially
            box.Text = placeholder;
            box.Foreground = Brushes.Gray;

            box.GotFocus += (s, e) =>
            {
                if (box.Text == placeholder)
                {
                    box.Text = "";
                    box.Foreground = Brushes.Black;
                }
            };

            box.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = placeholder;
                    box.Foreground = Brushes.Gray;
                }
            };
        }

        private void SongsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // changes title do item num when click on item
            if (songsListBox.Items.Count > 0) 
            {
                this.Title = songsListBox.SelectedItem.ToString();
                // lbl.Content = songsListBox.SelectedItem.ToString();
            }
            
        }

        int index = 0;
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            index++;
            this.songsListBox.Items.Add("Item " + index);
        }

        List<Song> songs = new List<Song>()
            {
                new Song{ Id = Guid.NewGuid().ToString(),Title="Song 1", Duration=3.20f },
                new Song{ Id = Guid.NewGuid().ToString(),Title="Song 2", Duration=2.20f },
                new Song{ Id = Guid.NewGuid().ToString(),Title="Song 3", Duration=1.20f }
            };
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            //this.songsListBox.ItemsSource = null;
            //this.songsListBox.ItemsSource = songs;

            var rangeList = songs
                .Where(s => s.Duration > 1f && s.Duration < 2.5f)
                .OrderBy(s => s.Duration);
            
            songsListBox.Items.Clear();
            foreach (Song s in rangeList)
            {
                songsListBox.Items.Add(s);
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLoadSongs_Click(object sender, RoutedEventArgs e)
        {
            // Use singleton service to generate 50 random songs
            var newSongs = RandomSongService.Instance.GenerateSongs(50);
            // add them to the existing list
            songsList.AddRange(newSongs);
            songsListBox.ItemsSource = null;    
            songsListBox.ItemsSource = songsList;   // refresh display
            UpdateStatistics();
        }

        private void btnDeleteSong_Click(object sender, RoutedEventArgs e)
        {
            if (songsListBox.SelectedItem is Song selectedSong)
            {
                songsList.Remove(selectedSong);
                // refresh the listbox
                songsListBox.ItemsSource = null;
                songsListBox.ItemsSource = songsList;
                UpdateStatistics();
            }
            else
            {
                MessageBox.Show("Please select a song to delete.");
            }
        }

        private void btnAddSong_Click(object sender, RoutedEventArgs e)
        {
            string artist = txtArtist.Text.Trim();
            string title = txtTitle.Text.Trim();
            string durationText = txtDuration.Text.Trim();

            // Validate not empty
            if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(durationText))
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            // Validate duration between 1–10
            if (!double.TryParse(durationText, out double duration) || duration < 1 || duration > 10)
            {
                MessageBox.Show("Duration must be a number between 1 and 10.");
                return;
            }

            // Add new song
            var newSong = new Song
            {
                Artist = artist,
                Title = title,
                Duration = Math.Round(duration, 1)
            };
            songsList.Add(newSong);

            // Refresh list
            songsListBox.ItemsSource = null;
            songsListBox.ItemsSource = songsList;

            // Restore placeholders
            SetPlaceholder(txtArtist, "Artist");
            SetPlaceholder(txtTitle, "Title");
            SetPlaceholder(txtDuration, "Duration (1–10)");
            UpdateStatistics();
        }

        // a flag to know how to sort duration
        private bool isDurationAscending = true;
        private void btnSortByDuration_Click(object sender, RoutedEventArgs e)
        {
            if (isDurationAscending)
            {
                // LINQ describes how to iterate
                songsList = songsList.OrderBy(s => s.Duration).ToList(); // Ascending (up)
            }
            else
            {
                songsList = songsList.OrderByDescending(s => s.Duration).ToList(); // Descending (down)
            }

            // switch for next click
            isDurationAscending = !isDurationAscending; 

            // Refresh list (this is where the iteration happens)
            songsListBox.ItemsSource = null;
            songsListBox.ItemsSource = songsList;
            UpdateStatistics();
        }

        // a flag to know how to sort titles
        private bool isTitleAscending = true;

        private void btnSortByTitle_Click(object sender, RoutedEventArgs e)
        {
            if (isTitleAscending)
            {
                // Sort A to Z
                songsList = songsList.OrderBy(s => s.Title).ToList();
            }
            else
            {
                // Sort Z to A
                songsList = songsList.OrderByDescending(s => s.Title).ToList();
            }

            // switch for next click
            isTitleAscending = !isTitleAscending;

            // Refresh the listbox
            songsListBox.ItemsSource = null;
            songsListBox.ItemsSource = songsList;
            UpdateStatistics();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            // ignore placeholder text
            if (string.IsNullOrEmpty(query) || query == "search song")
            {
                // If empty - sorted song list by titles
                songsList = songsList.OrderBy(s => s.Title).ToList();
                songsListBox.ItemsSource = null;
                songsListBox.ItemsSource = songsList;
                UpdateStatistics();
                return;
            }

            // Filter songs whose Title or Artist contain the search text
            var filteredSongs = songsList
                .Where(s =>
                    (!string.IsNullOrEmpty(s.Title) && s.Title.ToLower().Contains(query)) ||
                    (!string.IsNullOrEmpty(s.Artist) && s.Artist.ToLower().Contains(query))
                )
                .ToList();

            // Show filtered list
            songsListBox.ItemsSource = null;
            songsListBox.ItemsSource = filteredSongs;
            UpdateStatistics();

            // No song found
            if (filteredSongs.Count == 0)
            {
                MessageBox.Show("No matching songs found.");
            }

        }

        private void btnShortHits_Click(object sender, RoutedEventArgs e)
        {
            // Filter songs shorter than 3.0 minutes
            var shortHits = songsList
                .Where(s => s.Duration < 3.0)
                .OrderBy(s => s.Title) // sort ascending by title
                .ToList();

            if (shortHits.Count == 0)
            {
                MessageBox.Show("No short hits found (under 3 minutes).");
                return;
            }

            // Update the ListBox
            songsListBox.ItemsSource = null;
            songsListBox.ItemsSource = shortHits;
            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            if (songsList == null || songsList.Count == 0)
            {
                lblTotalDuration.Text = "Total Duration: 0";
                lblAverageLength.Text = "Average Length: 0.00";
                lblLongestSong.Text = "Longest Song: N/A";
                return;
            }

            // calculation of statistics
            double totalDuration = songsList.Sum(s => s.Duration);
            double averageLength = songsList.Average(s => s.Duration);
            var longestSong = songsList.OrderByDescending(s => s.Duration).First();

            lblTotalDuration.Text = $"Total Duration: {totalDuration:F2} min";
            lblAverageLength.Text = $"Average Length: {averageLength:F2} min";
            lblLongestSong.Text = $"Longest Song: {longestSong.Title}";
        }

        private void btnArtistsCount_Click(object sender, RoutedEventArgs e)
        {
            if (songsList == null || songsList.Count == 0)
            {
                MessageBox.Show("No songs available.");
                return;
            }

            // Group songs by Artist (case-insensitive, trim spaces)
            var groups = songsList
                .GroupBy(
                    s => string.IsNullOrWhiteSpace(s.Artist) ? "(Unknown)" : s.Artist.Trim(), // group by artists
                    StringComparer.CurrentCultureIgnoreCase)
                .OrderBy(g => g.Key) // Sort alphabetically by artist name
                .Select(g => $"{g.Key}: {g.Count()} song{(g.Count() == 1 ? "" : "s")}"); // s for plural

            // Join all lines into one text block
            string resultText = string.Join("\n", groups);

            // Show the results in a MessageBox
            MessageBox.Show(resultText, "Songs per Artist");
        }
    }
}