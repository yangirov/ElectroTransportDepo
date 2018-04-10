using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
    public class TransportsTypesController : Controller
    {
        private DepoContext db;

        public TransportsTypesController()
        {
            db = new DepoContext();
        }

        // GET: TransportsTypes
        public ActionResult Index()
        {
            return View(db.TransportsTypes.ToList());
        }

        // GET: TransportsTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportsTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransportsType TransportsType)
        {
            if (ModelState.IsValid)
            {
                db.TransportsTypes.Add(TransportsType);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(TransportsType);
        }

        // GET: TransportsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportsType TransportsType= db.TransportsTypes.Find(id);

            if (TransportsType == null)
            {
                return HttpNotFound();
            }

            return View(TransportsType);
        }

        // POST: TransportsTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransportsType TransportsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(TransportsType).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(TransportsType);
        }

        // GET: TransportsTypes/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            TransportsType TransportsType= db.TransportsTypes.Find(id);

            if (TransportsType == null)
            {
                return HttpNotFound();
            }

            return View(TransportsType);
        }

        // POST: TransportsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportsType TransportsType = db.TransportsTypes.Find(id);

            if (TransportsType == null)
            {
                return HttpNotFound();
            }

            db.TransportsTypes.Remove(TransportsType);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}