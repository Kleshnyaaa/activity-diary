using System;
using System.Collections.Generic;
using System.Linq;
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
        readonly AppUserManager _userManager;
        readonly IAuthenticationManager _authenticationManager;

        public UsersController()
        {
            _userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            _authenticationManager = HttpContext.GetOwinContext().Authentication;
        }

        // GET: Users
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser user;
            var userByEmail = _userManager.FindByEmail(model.NameOrMail);

            if (userByEmail == null)
            {
                user = _userManager.Find(model.NameOrMail, model.Password);
            }
            else
            {
                user = _userManager.Find(userByEmail.UserName, model.Password);
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Login or Password");
                return View(model);
            }

            var identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            

            // Verify user, set cookie and redirect somewhere
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //var _userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            AppUser user = new AppUser()
            {
                UserName = model.Name,
                Email = model.Email
            };
            // Add validation of case when User or Email is existing in DB
            var tmp = _userManager.Create(user, model.Password);
            return View();
        }
    }
}