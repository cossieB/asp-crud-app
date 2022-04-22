using IGDB.Data;
using IGDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace IGDB.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GamesController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Game> games = this._db.Games;
            return View(games);
        }
        public IActionResult Create()
        {
            var obj = new GameDetails();
            var game = new Game();
            var developers = this._db.Developers.ToList<Developer>();
            var publishers = this._db.Publishers.ToList<Publisher>();

            obj.Game = game;
            obj.Developers = developers;
            obj.Publishers = publishers;
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            var rgx = new Regex(@"^https?:\/\/.+\.(png|jpg|jpeg|svg|webp)$", RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(game.CoverImg))
            {
                ModelState.AddModelError("CoverImg", "Please enter a valid image file.");
            }
            if (ModelState.IsValid)
            {
                this._db.Games.Add(game);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }
        public IActionResult Edit(int id)
        {
            var game = this._db.Games.Find(id);
            if (game == null) return NotFound();

            var obj = new GameDetails();
            var developers = this._db.Developers.ToList<Developer>();
            var publishers = this._db.Publishers.ToList<Publisher>();

            obj.Game = game;
            obj.Developers = developers;
            obj.Publishers = publishers;
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Game game)
        {
            var rgx = new Regex(@"^https?:\/\/.+\.(png|jpg|jpeg|svg|webp)$", RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(game.CoverImg))
            {
                ModelState.AddModelError("Logo", "Please enter a valid image file.");
            }
            if (ModelState.IsValid)
            {
                this._db.Games.Update(game);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }
        public IActionResult Delete(int id)
        {
            var game = this._db.Games.Find(id);
            if (game == null) return NotFound();

            var obj = new GameDetails();
            var developers = this._db.Developers.ToList();
            var publishers = this._db.Publishers.ToList();

            obj.Game = game;
            obj.Developers = developers;
            obj.Publishers = publishers;
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Game game)
        {
            this._db.Games.Remove(game);
            this._db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var game = this._db.Games.Find(id);
            if (game == null) return NotFound();

            game.Developer = this._db.Developers.Find(game.DeveloperId);
            game.Publisher = this._db.Publishers.Find(game.PublisherId);
            return View(game);
        }
    }
}
