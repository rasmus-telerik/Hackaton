﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class WorkersController : BaseDispatchController
    {
        public ActionResult All()
        {
            return View();
        }

        public ActionResult AssignRoute()
        {
            return View();
        }
    }
}
