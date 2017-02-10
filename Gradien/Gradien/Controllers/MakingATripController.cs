using Gradien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradien.Controllers
{
    public class MakingATripController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BookingModels booking)
        {
            GDbContext db = new GDbContext();
            if (ModelState.IsValid)
            {
                db.Booking.Add(booking);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(booking);
            }
        }

        public ActionResult MakingATrip()
        {
            return View();
        }
        
    }
}