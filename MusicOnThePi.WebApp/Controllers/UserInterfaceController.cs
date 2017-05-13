using Microsoft.AspNetCore.Mvc;

namespace MusicOnThePi.WebApp.Controllers
{
    [Route("")]
    public class UserInterfaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
