using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Everlive.Sdk.Core.Model.System;
using WebApplication.Engine;
using WebApplication.Engine.Model;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LocationsController : BaseDispatchController
    {
        public ActionResult All()
        {
            var tasks = this.eManager.GetTasksByOwner(this.EntityUser.EverliveGuid, 0, 1000);
            return View(tasks.Select(t => new LocationModel()
                {
                    Address = string.IsNullOrEmpty(t.Address) ? t.Location.Latitude.ToString() + ", " + t.Location.Longitude.ToString() : t.Address,
                    Description = t.Description,
                    Customer = this.eManager.GetUserById(t.Customer) != null ? this.eManager.GetUserById(t.Customer).DisplayName : "",
                    VisitTime = t.TimeInMins.ToString()
                }));
        }

        [HttpPost]
        public ActionResult Add(LocationModel model)
        {
            var mgr = this.eManager;

            var customer = mgr.App.WorkWith().Users().Get().Where(u => u.DisplayName == model.Customer.Trim()).ExecuteSync().FirstOrDefault();
            Guid customerId;
            if (customer == null)
            {
                customerId = mgr.Create(new User()
                    {
                        DisplayName = model.Customer.Trim(),
                        Username = Guid.NewGuid().ToString(),
                        Password = Guid.NewGuid().ToString()
                    });
            }
            else
            {
                customerId = customer.Id;
            }

            var taskId = mgr.Create(new Task()
                {
                    Customer = customerId,
                    Address = model.Address.Trim(),
                    Description = model.Description.Trim(),
                    TimeInMins = int.Parse(model.VisitTime)
                });
            mgr.SetOwner<Task>(taskId, this.EntityUser.EverliveGuid);
            return this.RedirectToAction("All");
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
