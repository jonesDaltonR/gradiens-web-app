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
        [Authorize] // Requires user to be logged in to access
        [HttpGet]
        // Sign out user
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // Log out
            return RedirectToAction("Index", "Home"); // Return to home page
        }


        // Login page
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // Retrieve data from user input
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

            if(user == null) // User doesn't exist
            {
                ModelState.AddModelError(string.Empty, "User/password combination does not exist.");
                login.USER_PASSWORD = string.Empty; // Clear password
                return View(login);
            }

            if (user != null) // If user exists
            {
                login.USER_PASSWORD = Hash(Encoding.ASCII.GetBytes(login.USER_PASSWORD),
                    Encoding.ASCII.GetBytes(user.USER_PASSWORD_SALT)); // Hash user input for password comparison
            }

            // Compare user input to users in the database
            if (login.USER_EMAIL.Equals(user.USER_EMAIL) &&     // Matching user email and password
                login.USER_PASSWORD.Equals(user.USER_PASSWORD)) // was found in the database
            {
                if (user.ADMIN_CONTROLS == true) // Admin role
                {
                    string roles = "Admin"; // Administrator
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    2, // Version
                    login.USER_EMAIL, // User email
                    DateTime.Now, // Time issued
                    DateTime.Now.AddMinutes(120), // Expire time
                    false, // Do not remember cookie
                    roles, // Role(s)
                    "/"); // Cookie path
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, 
                        FormsAuthentication.Encrypt(authTicket)); // Set cookie
                    Response.Cookies.Add(cookie); // Add cookie
                    return Redirect("/Admin/"); // Redirect to admin page
                }
                else // User role
                {
                    string roles = "User"; // User
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    2, // Version
                    login.USER_EMAIL, // User email
                    DateTime.Now, // Time issued
                    DateTime.Now.AddMinutes(120), // Expire time
                    false, // Do not remember cookie
                    roles, // Role(s)
                    "/"); // Cookie path
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, 
                        FormsAuthentication.Encrypt(authTicket)); // Set cookie
                    Response.Cookies.Add(cookie); // Add cookie
                }

                return Redirect("/");
            }

            else
            {
                ViewBag.Message("User/password combination does not exist.");
                login.USER_PASSWORD = string.Empty; // Clear password
                return View(login);
            }
        }

        // Registration page
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        // Retrieve data from user input
        public ActionResult Registration(UserModels user)
        {
            if (ModelState.IsValid) // Check for valid ModelState
            {
                try
                {
                    GDbContext db = new GDbContext(); // Establish connection to the database
                    user.USER_PASSWORD_SALT = GenerateSalt(); // Generate password salt
                    user.USER_PASSWORD = Hash(Encoding.ASCII.GetBytes(user.USER_PASSWORD),
                        Encoding.ASCII.GetBytes(user.USER_PASSWORD_SALT)); // Hash password with password salt

                    db.User.Add(user); // Add user to the datebase
                    db.SaveChanges(); // Save changes to the database
                    return RedirectToAction("Login"); // Redirect to login page

                } catch(Exception) // Catch unique constraint violation for email
                {
                    user.USER_PASSWORD = string.Empty; // Clear password
                    ModelState.AddModelError(string.Empty, "This email is already in use.");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        // Generate password salt
        public static string GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider()) // Randomly generate salt
            {
                byte[] salt = new byte[32]; // Holds salt
                rng.GetBytes(salt); // Generates salt
                return Encoding.UTF8.GetString(salt); // Encode salt
            }
        }

        // Hash password with salt
        public static string Hash(byte[] data, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt)) // Use salt to hash
            {
                return Encoding.UTF8.GetString(hmac.ComputeHash(data)); // Return hashed password
            }
        }
    }
}
