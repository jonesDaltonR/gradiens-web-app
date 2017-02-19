using Gradien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradien.Controllers
{
    public class HomeController : Controller
    {
        // Returns Home page
        public ActionResult Index()
        {
            return View();
        }

        // Returns About page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // Returns Contact Us page
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        // Returns Terms of Service page
        public ActionResult Terms()
        {
            return View();
        }

        // Returns Privacy Policy page
        public ActionResult Privacy()
        {
            return View();
        }

        // Returns FAQs page
        public ActionResult FAQ()
        {
            return View();
        }
    }
}