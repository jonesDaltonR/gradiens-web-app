using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradien.Controllers
{
    public class MakingATripController : Controller
    {
        // GET: MakingATrip
        public ActionResult Flights()
        {
            return View();
        }

        public ActionResult Hotels()
        {
            return View();
        }

        public ActionResult MakingATrip()
        {
            return View();
        }
        
    }
}