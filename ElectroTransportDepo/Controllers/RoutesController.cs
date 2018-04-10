using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
    public class RoutesController : Controller
    {
        private DepoContext db;

        public RoutesController()
        {
            db = new DepoContext();
        }

        // GET: Routes
        public ActionResult Index()
        {
            return View(db.Routes.ToList());
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            SelectList depos = new SelectList(db.Depos, "Id", "Name");
            ViewBag.Depos = depos;

            SelectList transportsTypes = new SelectList(db.TransportsTypes, "Id", "Name");
            ViewBag.TransportsTypes = transportsTypes;

            return View();
        }

        // POST: Routes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Route route)
        {
            if (!ModelState.IsValid)
            {
                return View(route);
            }

            db.Routes.Add(route);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Route route = db.Routes.Find(id);

            if (route != null)
            {
                SelectList depos = new SelectList(db.Depos, "Id", "Name");
                ViewBag.Positions = depos;

                SelectList transportsTypes = new SelectList(db.TransportsTypes, "Id", "Name");
                ViewBag.TransportsTypes = transportsTypes;

                return View(route);
            }
            return RedirectToAction("Index");
        }

        // POST: Routes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(route);
        }

        // GET: Routes/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Route route = db.Routes.Find(id);

            if (route == null)
            {
                return HttpNotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Routes.Find(id);

            if (route == null)
            {
                return HttpNotFound();
            }

            db.Routes.Remove(route);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}