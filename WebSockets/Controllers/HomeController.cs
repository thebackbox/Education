using System.Web.Mvc;

namespace WebSockets.Controllers {
    public sealed class HomeController : Controller {
        public ActionResult Index()
        {
            return View();
        }
    }
}