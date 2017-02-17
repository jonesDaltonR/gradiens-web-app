using Gradien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gradien.Controllers
{
    [AdminAuthorize(Roles = "Admin")] // Requires user to be logged in as admin to access
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut(); // Log out
            return RedirectToAction("Index", "Home"); // Return to home page
        }

        // Main admin page
        public ActionResult Index()
        {
            return View();
        }

        // View users in the database
        public ActionResult UserList()
        {
            List<UserModels> users = new List<UserModels>(); // Holds users

            GDbContext db = new GDbContext(); // Establish connection to database

            users = db.User.ToList(); // Retrieve users from database

            return View(users); // Send users in a list view
        }

        // Inquite specific user
        public ActionResult UserDetails(int id)
        {
            GDbContext db = new GDbContext(); // Establish connection to database
            
            // Retrieve user from database
            UserModels user = db.User.SingleOrDefault(u => u.USER_ID == id) as UserModels;

            if (user == null) // Return error if user isn't found
            {
                return HttpNotFound();
            }
            return View(user); // Send user in a detail view
        }

        public ActionResult UserDelete(int id)
        {
            GDbContext db = new GDbContext(); // Establish connection to database

            // Retrieve user from database
            UserModels user = db.User.SingleOrDefault(u => u.USER_ID == id) as UserModels;

            if (user == null) // Return error if user isn't found
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid) // Check for valid ModelState
            {
                user.DELETE_STAT = !user.DELETE_STAT; // Soft delete or undelete based on current status
                db.SaveChanges(); // Save changes to datebase

                return RedirectToAction("UserList"); // Return updated user list page
            }
            
            return View(user); // Returns view, should not occur
        }


        // Hotels

        // View Hotels in the database
        public ActionResult HotelList()
        {
            List<Hotels> hotels = new List<Hotels>(); // Holds hotels

            GDbContext db = new GDbContext(); // Establish connection to database

            hotels = db.Hotel.ToList(); // Retrieve hotels from database

            return View(hotels); // Send hotels in a list view
        }

        public ActionResult HotelDetails(int id)
        {
            GDbContext db = new GDbContext(); // Establish connection to database
            
            // Retrieve hotel from database
            Hotels hotel = db.Hotel.SingleOrDefault(h => h.HOTEL_ID == id) as Hotels;

            if (hotel == null) // Return error if hotel isn't found
            {
                return HttpNotFound();
            }
            return View(hotel); // Send hotel in a detail view
        }

        public ActionResult HotelDelete(int id)
        {
            GDbContext db = new GDbContext(); // Establish connection to database

            // Retrieve hotel from database
            Hotels hotel = db.Hotel.SingleOrDefault(h => h.HOTEL_ID == id) as Hotels;

            if (hotel == null) // Return error if hotel isn't found
            {
                return HttpNotFound();
            }
            
            if (ModelState.IsValid) // Check for valid ModelState
            {
                hotel.DELETE_STAT = !hotel.DELETE_STAT; // Soft delete or undelete based on current status
                db.SaveChanges(); // Save changes to datebase

                return RedirectToAction("HotelList"); // Return to hotel list
            }

            return View(hotel); // Returns view, should not occur
        }
    }

    // Custom role for admins
    public class AdminAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // If they are authorized, handle accordingly
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                // Otherwise redirect to your specific authorized area
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}