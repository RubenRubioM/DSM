using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMeUI.Controllers
{
    public class ErrorController : BasicController
    {
        public ActionResult SinSesion()
        {
            return View();
        }

        public ActionResult NoActivo()
        {
            return View();
        }
    }
}
