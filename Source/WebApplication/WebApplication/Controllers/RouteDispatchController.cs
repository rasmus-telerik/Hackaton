using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RouteDispatchController : BaseDispatchController
    {
        public ActionResult All()
        {
            return View();
        }

        public ActionResult ViewRoute()
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
