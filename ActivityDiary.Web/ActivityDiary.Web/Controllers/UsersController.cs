using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}