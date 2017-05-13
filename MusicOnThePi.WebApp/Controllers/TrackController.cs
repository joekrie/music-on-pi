using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicOnThePi.WebApp.ViewModels.Track;
using Microsoft.Extensions.FileProviders;
using MongoDB.Driver;

namespace MusicOnThePi.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TrackController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IMongoDatabase _mongoDb;

        public TrackController(IFileProvider fileProvider, IMongoDatabase mongoDb)
        {
            _fileProvider = fileProvider;
            _mongoDb = mongoDb;
        }

        [HttpGet]
        public TrackCollectionViewModel Get()
        {
            return new TrackCollectionViewModel
            {
                Name = "Classics",
                Artist = "Ratatat",
                Category = "Rock",
                Tracks = new List<TrackViewModel>
                {
                    new TrackViewModel
                    {
                        Name = "Montanita",
                        FilePath = "ratatat__classics/01-Montanita.flac",
                        MimeType = "audio/flac"
                    },
                    new TrackViewModel
                    {
                        Name = "Lex",
                        FilePath = "ratatat__classics/02-Lex.flac",
                        MimeType = "audio/flac"
                    }
                }
            };
        }

        [HttpGet("play")]
        public IActionResult Play(string id)
        {
            var fileInfo = _fileProvider.GetFileInfo("Temp/ratatat__classics/01-Montanita.flac");
            var fileStream = fileInfo.CreateReadStream();
            return File(fileStream, "audio/flac");
        } 
    }
}
