using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ActivityDiary.Web.IdentityModels;
using ActivityDiary.ViewModels.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace ActivityDiary.Web.Controllers
{
    public class UsersController : Controller
    {
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Users
        public ActionResult LogIn()
        {
            // Change validation for not validated user
            // If user is not authenticated - redirect on general Index page with description and Login/Registration button
            // If user is authenticated - stay on Home/Index with personal dashboard

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser user;
            var userByEmail = UserManager.FindByEmail(model.NameOrEmail);

            if (userByEmail != null)
            {
                user = UserManager.Find(userByEmail.UserName, model.Password);
            }
            else
            {
                user = UserManager.Find(model.NameOrEmail, model.Password);
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Login or Password");
                return View(model);
            }

            ClaimsIdentity claim = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignOut();
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, claim);

            if (String.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Home");
            else
                return Redirect(returnUrl);
        }

        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //var UserManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            AppUser user = new AppUser()
            {
                UserName = model.Name,
                Email = model.Email
            };
            // Add validation of case when User or Email is existing in DB
            var tmp = UserManager.Create(user, model.Password);
            return RedirectToAction("Index", "Home");
        }
    }
}