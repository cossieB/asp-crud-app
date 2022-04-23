using IGDB.Data;
using IGDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IGDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this._db = db;
        }

        public IActionResult Index()
        {
            var obj = new HomeModel();
            obj.Games = this._db.Games.Take(6).ToList();
            obj.Publishers = this._db.Publishers.Take(6).ToList();
            obj.Developers = this._db.Developers.Take(6).ToList();
            return View(obj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}