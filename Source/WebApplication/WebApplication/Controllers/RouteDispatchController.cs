using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "Dispatcher")]
    public class RouteDispatchController : Controller
    {
        readonly UsersContext context;
        public UserProfile EntityUser
        {
            get
            {
                return this.context.UserProfiles.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            }
        }

        public RouteDispatchController()
        {
            this.context = new UsersContext();
        }

        public ActionResult All()
        {
            // get the everlive user by using the id of the entity user
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
