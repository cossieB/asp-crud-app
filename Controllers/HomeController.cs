using IGDB.Data;
using IGDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            var obj = new HomeModel();

            var gameQuery = from game in _db.Games
                            where EF.Functions.Like(game.Title, $"%{searchTerm}%")
                            select game;
            var devQuery = from dev in _db.Developers
                            where EF.Functions.Like(dev.Name, $"%{searchTerm}%")
                            select dev;
            var pubQuery = from pub in _db.Publishers
                            where EF.Functions.Like(pub.Name, $"%{searchTerm}%")
                            select pub;
            obj.Games = gameQuery.ToList();
            obj.Developers = devQuery.ToList();
            obj.Publishers = pubQuery.ToList();
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