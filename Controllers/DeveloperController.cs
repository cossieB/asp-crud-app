using IGDB.Data;
using IGDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace IGDB.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DeveloperController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Developer> developers = this._db.Developers;
            return View(developers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Developer obj)
        {
            var rgx = new Regex(@"^https?:\/\/.+\.(png|jpg|jpeg|svg|webp)$", RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(obj.Logo))
            {
                ModelState.AddModelError("Logo", "Please enter a valid image file.");
            }
            if (ModelState.IsValid)
            {
                this._db.Developers.Add(obj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int id)
        {
            var obj = this._db.Developers.Find(id);
            if (obj == null) return NotFound();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Developer obj)
        {
            var rgx = new Regex(@"^https?:\/\/.+\.(png|jpg|jpeg|svg|webp)$", RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(obj.Logo))
            {
                ModelState.AddModelError("Logo", "Please enter a valid image file.");
            }
            if (ModelState.IsValid)
            {
                this._db.Developers.Update(obj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var obj = this._db.Developers.Find(id);
            if (obj == null) return NotFound();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Developer obj)
        {
                this._db.Developers.Remove(obj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var obj = this._db.Developers.Find(id);
            if (obj == null) return NotFound();
            return View(obj);
        }
    }
}
