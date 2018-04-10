using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
    public class CitiesController : Controller
    {
        private DepoContext db;

        public CitiesController()
        {
            db = new DepoContext();
        }

        // GET: Cities
        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city= db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: Cities/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            City city= db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            db.Cities.Remove(city);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}