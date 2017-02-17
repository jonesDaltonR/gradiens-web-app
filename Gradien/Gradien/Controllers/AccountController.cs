using Gradien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gradien.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModels login)
        {

            if (login.USER_EMAIL == null || login.USER_PASSWORD == null)
            {
                ModelState.AddModelError(string.Empty, "missing username and/or password");
                return View(login);
            }
            
            if (!new EmailAddressAttribute().IsValid(login.USER_EMAIL))
            {
                ModelState.AddModelError(string.Empty, "invalid e-mail address");
                return View(login);
            }

            GDbContext db = new GDbContext();
            UserModels user = db.User.SingleOrDefault(u => u.USER_EMAIL == login.USER_EMAIL) as UserModels;

            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "No user found");
                return View(login);
            }

            if (user != null)
            {
                login.USER_PASSWORD = Hash(Encoding.ASCII.GetBytes(login.USER_PASSWORD),
                    Encoding.ASCII.GetBytes(user.USER_PASSWORD_SALT));
            }

            if (login.USER_EMAIL.Equals(user.USER_EMAIL) && login.USER_PASSWORD.Equals(user.USER_PASSWORD))
            {

                //FormsAuthentication.SetAuthCookie(login.USER_EMAIL, true);

                if (user.ADMIN_CONTROLS == true)
                {
                    /// Use following line for admin authorization
                    /// [Authorize(Roles = "Admin" )]
                    ///

                    string roles = "Admin"; //Administrator,Contestant
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    2,              // version
                    login.USER_EMAIL,   // user id
                    DateTime.Now,   // issue dtm
                    DateTime.Now.AddMinutes(120),  // expiry dtm
                    false,          // do not remember cookie
                    roles,          // role(s)
                    "/");           // cookie path
                                    //FormsAuthentication.SetAuthCookie(login.UserId, true);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                    return Redirect("/Admin/");
                }
                else
                {
                    string roles = "User"; //Administrator,Contestant
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    2,              // version
                    login.USER_EMAIL,   // user id
                    DateTime.Now,   // issue dtm
                    DateTime.Now.AddMinutes(120),  // expiry dtm
                    false,          // do not remember cookie
                    roles,          // role(s)
                    "/");           // cookie path
                                    //FormsAuthentication.SetAuthCookie(login.UserId, true);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                }

                return Redirect("/");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "User/password combination does not exist.");
                return View(login);
            }
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModels user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GDbContext db = new GDbContext();
                    user.USER_PASSWORD_SALT = GenerateSalt();
                    user.USER_PASSWORD = Hash(Encoding.ASCII.GetBytes(user.USER_PASSWORD),
                        Encoding.ASCII.GetBytes(user.USER_PASSWORD_SALT));

                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");

                } catch(Exception)
                {
                    user.USER_PASSWORD = string.Empty;
                    ModelState.AddModelError(string.Empty, "This email is already in use.");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        public static string GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32];
                rng.GetBytes(salt);
                return Encoding.UTF8.GetString(salt);
            }
        }

        public static string Hash(byte[] data, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                return Encoding.UTF8.GetString(hmac.ComputeHash(data));
            }
        }
    }
}
