using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
    public class PositionsController : Controller
    {
        private DepoContext db;

        public PositionsController()
        {
            db = new DepoContext();
        }

        // GET: Positions
        public ActionResult Index()
        {
            return View(db.Positions.ToList());
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Position position= db.Positions.Find(id);

            if (position == null)
            {
                return HttpNotFound();
            }

            return View(position);
        }

        // POST: Positions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: Positions/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Position position= db.Positions.Find(id);

            if (position == null)
            {
                return HttpNotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);

            if (position == null)
            {
                return HttpNotFound();
            }

            db.Positions.Remove(position);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}