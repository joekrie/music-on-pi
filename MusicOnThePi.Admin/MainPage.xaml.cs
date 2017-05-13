using System;
using System.Linq;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MusicOnThePi.Admin
{
    public sealed partial class MainPage : Page
    {
        private readonly MediaPlayer _mediaPlayer = new MediaPlayer
        {
            AudioCategory = MediaPlayerAudioCategory.Media
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayFile(string path)
        {
            try
            {
                var sourceUri = new Uri(string.Format(path, UriKind.Absolute));
                var mediaSource = MediaSource.CreateFromUri(sourceUri);
                _mediaPlayer.Source = mediaSource;
                _mediaPlayer.Play();
            }
            catch
            {
                Error.Text = $"Couldn't play {path}";
            }
        }

        private void PlayMp3_Click(object sender, RoutedEventArgs e)
        {
            PlayFile("ms-appx:///Assets/swords-of-fire.mp3");
        }

        private void PlayAac_Click(object sender, RoutedEventArgs e)
        {
            PlayFile("ms-appx:///Assets/sail.m4a");
        }

        private void PlayFlac_Click(object sender, RoutedEventArgs e)
        {
            PlayFile("ms-appx:///Assets/rhapsody-in-blue.flac");
        }

        private void PlayWav_Click(object sender, RoutedEventArgs e)
        {
            PlayFile("ms-appx:///Assets/dramatic.wav");
        }

        private void PlayAll_Click(object sender, RoutedEventArgs e)
        {
            var playlist = new MediaPlaybackList();
            playlist.CurrentItemChanged += MediaPlaybackList_CurrentItemChanged;
            var paths = new[] 
            {
                "ms-appx:///Assets/swords-of-fire.mp3",
                "ms-appx:///Assets/sail.m4a",
                "ms-appx:///Assets/rhapsody-in-blue.flac",
                "ms-appx:///Assets/dramatic.wav"
            };
            foreach (var path in paths)
            {
                var sourceUri = new Uri(string.Format(path, UriKind.Absolute));
                var mediaSource = MediaSource.CreateFromUri(sourceUri);
                var item = new MediaPlaybackItem(mediaSource);
                playlist.Items.Add(item);
            }
            _mediaPlayer.Source = playlist;
            _mediaPlayer.Play();
        }

        private async void MediaPlaybackList_CurrentItemChanged(MediaPlaybackList sender, CurrentMediaPlaybackItemChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Error.Text = args.NewItem.AudioTracks.First().Name;
            });
        }

        private void PlayNetwork_Click(object sender, RoutedEventArgs e)
        {
            PlayFile("http://192.168.1.100:8081/split-needles.mp3");
        }
    }
}
