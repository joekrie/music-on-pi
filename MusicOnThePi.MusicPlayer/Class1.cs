using Windows.ApplicationModel.Background;

namespace MusicOnThePi.MusicPlayer
{
    public sealed class Class1 : IBackgroundTask
    {
        private BackgroundTaskDeferral _deferral;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
        }
    }
}
