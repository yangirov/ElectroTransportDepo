using System.Web.Mvc;

namespace ElectroTransportDepo.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error/NotFound
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        // GET: Error/Forbidden
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}