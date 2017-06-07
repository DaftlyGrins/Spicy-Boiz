using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace davidsProperties.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Staff()
        {
            return View();
        }

        public ActionResult PropertyManager()
        {
            return View();
        }

        public ActionResult PropertyOwner()
        {
            return View();
        }

        public ActionResult ProspectiveTenant()
        {
            return View();
        }

        public ActionResult Tenant()
        {
            return View();
        }

        public ActionResult AddProperty()
        {
            return View();
        }

        public ActionResult UpdateProperty()
        {
            return View();
        }
    }
}