using Gradien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradien.Controllers
{
    public class HotelController : Controller
    {
        GDbContext db = new GDbContext();
        //string city, state, name;

        //public ActionResult searchTerms(string city,string state,string name)
        //{
        //    this.city = city;
        //    this.state = state;
        //    this.name = name;
        //}

        public ActionResult Index()
        {
            List<Hotels> hotels = (from records in db.Hotel where records.HOTEL_CITY == "Chicago" select records).ToList<Hotels>();
            return View(hotels);
        }

    }
}