using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RouteDispatchController : BaseDispatchController
    {
        public ActionResult All()
        {
            // get the everlive user by using the id of the user
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
