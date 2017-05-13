using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MusicOnThePi.WebApp.ViewModels.Upload
{
    public class UploadStep1ViewModel
    {
        public string Album { get; set; }
        public string Artist { get; set; }
        public List<IFormFile> TrackFiles { get; set; }
    }
}
