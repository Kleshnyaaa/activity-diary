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
        private UsersService _usersService
        {
            get
            {
                return new UsersService(HttpContext);
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

            if (!_usersService.LogIn(model.NameOrEmail, model.Password))
            {
                ModelState.AddModelError("", "Invalid Login or Password");
                return View(model);
            }// Else User is loged In

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

            _usersService.RegisterUser(model.Name, model.Email, model.Password);

            return RedirectToAction("Index", "Home");
        }
    }
}