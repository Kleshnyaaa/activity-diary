using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActivityDiary.Web.IdentityModels;
using ActivityDiary.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ActivityDiary.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        // Should be modified. There is now simple example of creating new user
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            AppUser user = new AppUser()
            {
                UserName = model.Name
            };
            userManager.Create(user, model.Password);
            return View();
        }
    }
}