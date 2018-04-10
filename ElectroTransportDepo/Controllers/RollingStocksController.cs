using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
    public class RollingStocksController : Controller
    {
        private DepoContext db;

        public RollingStocksController()
        {
            db = new DepoContext();
        }

        // GET: RollingStocks
        public ActionResult Index()
        {
            return View(db.RollingStocks.ToList());
        }

        // GET: RollingStocks/Create
        public ActionResult Create()
        {
            SelectList transportsTypes = new SelectList(db.TransportsTypes, "Id", "Name");
            ViewBag.TransportsTypes = transportsTypes;

            return View();
        }

        // POST: RollingStocks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RollingStock rollingStock)
        {
            if (!ModelState.IsValid)
            {
                return View(rollingStock);
            }

            db.RollingStocks.Add(rollingStock);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: RollingStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RollingStock rollingStock = db.RollingStocks.Find(id);

            if (rollingStock != null)
            {
                SelectList transportsTypes = new SelectList(db.TransportsTypes, "Id", "Name");
                ViewBag.TransportsTypes = transportsTypes;

                return View(rollingStock);
            }
            return RedirectToAction("Index");
        }

        // POST: RollingStocks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RollingStock rollingStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rollingStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rollingStock);
        }

        // GET: RollingStocks/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            RollingStock rollingStock = db.RollingStocks.Find(id);

            if (rollingStock == null)
            {
                return HttpNotFound();
            }

            return View(rollingStock);
        }

        // POST: RollingStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RollingStock rollingStock = db.RollingStocks.Find(id);

            if (rollingStock == null)
            {
                return HttpNotFound();
            }

            db.RollingStocks.Remove(rollingStock);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}