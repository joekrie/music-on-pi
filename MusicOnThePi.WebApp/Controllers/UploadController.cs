using Microsoft.AspNetCore.Mvc;
using MusicOnThePi.WebApp.ViewModels.Upload;

namespace MusicOnThePi.WebApp.Controllers
{
    [Route("upload")]
    public class UploadController : Controller
    {
        [HttpGet("step-1")]
        public IActionResult UploadStep1()
        {
            return View(new UploadStep1ViewModel());
        }

        [HttpPost("step-1")]
        public IActionResult UploadStep1(UploadStep1ViewModel viewModel)
        {

            return View();
        }

        [HttpGet("step-2")]
        public IActionResult UploadStep2()
        {
            return View(new UploadStep2ViewModel());
        }

        [HttpPost("step-2")]
        public IActionResult UploadStep2(UploadStep2ViewModel viewModel)
        {
            return View();
        }
    }
}
