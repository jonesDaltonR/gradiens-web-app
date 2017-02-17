using Gradien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gradien.Controllers
{
    [AdminAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            List<UserModels> users = new List<UserModels>();

            GDbContext db = new GDbContext();

            users = db.User.ToList();

            return View(users);
        }

        public ActionResult UserDetails(int id)
        {
            GDbContext db = new GDbContext();

            ViewBag.Message = "User details form";
            UserModels user = db.User.SingleOrDefault(u => u.USER_ID == id) as UserModels;

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult UserDelete(int id)
        {
            GDbContext db = new GDbContext();

            ViewBag.Message = "User details form";
            UserModels user = db.User.SingleOrDefault(u => u.USER_ID == id) as UserModels;

            if (user == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                user.DELETE_STAT = !user.DELETE_STAT;
                db.SaveChanges();

                return RedirectToAction("UserList");
            }
            
            return View(user);
        }
    }

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