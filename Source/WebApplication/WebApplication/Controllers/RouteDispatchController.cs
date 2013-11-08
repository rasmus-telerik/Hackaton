using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [Authorize(Roles="Dispatcher")]
    public class RouteDispatchController : Controller
    {
        public ActionResult All()
        {
            return View();
        }

        public ActionResult View()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
