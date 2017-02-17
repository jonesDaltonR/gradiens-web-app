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


        //Take Results from Home page, displays to Search Page
        [HttpPost]
        public ActionResult Index()
        {
            string city = Request["selectLocation"].ToString();

            if (Request["txtName"].ToString() == "")
            {
                if (Request["selectLocation"].ToString() == "")
                {
                    List<Hotels> hotels = (from records in db.Hotel select records).ToList<Hotels>();
                    return View(hotels);
                }
                else
                {
                    List<Hotels> hotels = (from records in db.Hotel where records.HOTEL_CITY == city select records).ToList<Hotels>();
                    return View(hotels);
                }

            }
            else
            {
                string name = Request["txtName"].ToString();
                if (Request["selectLocation"].ToString() == "")
                {
                    List<Hotels> hotels = (from records in db.Hotel where records.HOTEL_NAME.Contains(name) select records).ToList<Hotels>();
                    return View(hotels);
                }
                else
                {
                    List<Hotels> hotels = (from records in db.Hotel where records.HOTEL_CITY == city && records.HOTEL_NAME.Contains(name) select records).ToList<Hotels>();
                    return View(hotels);
                }
            }
        }

    }
}