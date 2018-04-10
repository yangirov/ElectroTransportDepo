using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
    public class DeposController : Controller
    {
        private DepoContext db;

        public DeposController()
        {
            db = new DepoContext();
        }

        // GET: Depos
        public ActionResult Index()
        {
            return View(db.Depos.ToList());
        }

        // GET: Depos/Create
        public ActionResult Create()
        {
            SelectList cities = new SelectList(db.Cities, "Id", "Name");
            ViewBag.Cities = cities;

            return View();
        }

        // POST: Depos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Depo depo)
        {
            if (!ModelState.IsValid)
            {
                return View(depo);
            }

            db.Depos.Add(depo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Depos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Depo depo = db.Depos.Find(id);

            if (depo != null)
            {
                SelectList cities = new SelectList(db.Cities, "Id", "Name");
                ViewBag.Cities = cities;

                return View(depo);
            }
            return RedirectToAction("Index");
        }

        // POST: Depos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Depo depo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depo);
        }

        // GET: Depos/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Depo depo = db.Depos.Find(id);

            if (depo == null)
            {
                return HttpNotFound();
            }

            return View(depo);
        }

        // POST: Depos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Depo depo = db.Depos.Find(id);

            if (depo == null)
            {
                return HttpNotFound();
            }

            db.Depos.Remove(depo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}