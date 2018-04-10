using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
    public class EmployeesController : Controller
    {
        private DepoContext db;

        public EmployeesController()
        {
            db = new DepoContext();
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            SelectList positions = new SelectList(db.Positions, "Id", "Name");
            ViewBag.Positions = positions;

            SelectList depos = new SelectList(db.Depos, "Id", "Name");
            ViewBag.Depos = depos;

            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = db.Employees.Find(id);

            if (employee != null)
            {
                SelectList positions = new SelectList(db.Positions, "Id", "Name", employee.Position.Id);
                ViewBag.Brands = positions;

                SelectList depos = new SelectList(db.Depos, "Id", "Name");
                ViewBag.Depos = depos;

                return View(employee);
            }
            return RedirectToAction("Index");
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}