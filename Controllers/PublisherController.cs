using IGDB.Data;
using IGDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace IGDB.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Publisher> publishers = this._db.Publishers;
            return View(publishers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Publisher publisher)
        {
            var rgx = new Regex(@"^https?:\/\/.+\.(png|jpg|jpeg|svg|webp)$", RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(publisher.Logo))
            {
                ModelState.AddModelError("Logo", "Please enter a valid image file.");
            }
            if (ModelState.IsValid)
            {
                this._db.Publishers.Add(publisher);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        public IActionResult Edit(int id)
        {
            var publisher = this._db.Publishers.Find(id);
            if (publisher == null) return NotFound();
            return View(publisher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Publisher publisher)
        {
            var rgx = new Regex(@"^https?:\/\/.+\.(png|jpg|jpeg|svg|webp)$", RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(publisher.Logo))
            {
                ModelState.AddModelError("Logo", "Please enter a valid image file.");
            }
            if (ModelState.IsValid)
            {
                this._db.Publishers.Update(publisher);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        public IActionResult Delete(int id)
        {
            var publisher = this._db.Publishers.Find(id);
            if (publisher == null) return NotFound();
            return View(publisher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Publisher publisher)
        {
                this._db.Publishers.Remove(publisher);
                this._db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
