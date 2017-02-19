using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradien.Controllers
{
    public class SupportController : Controller
    {
        // Return Contact Us page
        public ActionResult Contact()
        {
            return View();
        }

        // Return Feedback page (currently not available)
        //public ActionResult Feedback()
        //{
        //    return View();
        //}
        
    }
}