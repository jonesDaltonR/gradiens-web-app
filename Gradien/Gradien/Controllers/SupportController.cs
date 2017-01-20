using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradien.Controllers
{
    public class SupportController : Controller
    {
        // GET: Support
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }

        public ActionResult SubmitTicket()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }
    }
}