using System.Linq;
using System.Web.Mvc;
using ElectroTransportDepo.Models;

namespace ElectroTransportDepo.Controllers
{
	public class HomeController : Controller
	{
        private DepoContext db;

        public HomeController()
        {
            db = new DepoContext();
        }

        public ActionResult Index() => View(db.Depos.ToList());
    }
}