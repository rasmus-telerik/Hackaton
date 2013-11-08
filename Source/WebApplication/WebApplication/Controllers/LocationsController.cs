using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class LocationsController : BaseDispatchController
    {
        public ActionResult All()
        {
            var tasks = this.eManager.GetTasksByOwner(this.EntityUser.EverliveGuid, 0, 1000);
            return View(tasks);
        }

        public ActionResult Add()
        {
            return View();
        }

        // TODO: implement in the future
        public ActionResult Edit()
        {
            return View();
        }

        // TODO: implement in the future
        public ActionResult Delete()
        {
            return View();
        }
    }
}
