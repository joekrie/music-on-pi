using System.Collections.Generic;

namespace MusicOnThePi.WebApp.ViewModels.Track
{
    public class TrackCollectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Category { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
        public IList<TrackViewModel> Tracks { get; set; } = new List<TrackViewModel>();
    }
}
