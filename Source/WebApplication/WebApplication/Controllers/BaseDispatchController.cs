using System.Linq;
using System.Web.Mvc;
using WebApplication.Engine;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "Dispatcher")]
    public class BaseDispatchController : Controller
    {
        protected readonly UsersContext context;
        protected readonly ElDataManager eManager;

        public UserProfile EntityUser
        {
            get
            {
                return this.context.UserProfiles.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            }
        }

        public BaseDispatchController()
        {
            this.context = new UsersContext();
            this.eManager = new ElDataManager();
        }
    }
}
