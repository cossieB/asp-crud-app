using Microsoft.AspNetCore.Mvc;

namespace IGDB.Controllers
{
    public class PlatformController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
