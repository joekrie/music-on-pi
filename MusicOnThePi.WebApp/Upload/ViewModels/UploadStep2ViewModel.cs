using System.Collections.Generic;

namespace MusicOnThePi.WebApp.ViewModels.Upload
{
    public class UploadStep2ViewModel
    {
        public List<Track> Tracks { get; set; }

        public class Track
        {
            public string TrackName { get; set; }
        }
    }
}
