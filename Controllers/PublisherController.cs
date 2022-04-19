using IGDB.Data;
using IGDB.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (ModelState.IsValid)
            {
                this._db.Publishers.Add(publisher);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
    }
}
