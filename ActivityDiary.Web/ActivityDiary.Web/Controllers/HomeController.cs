using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.ComponentModel.DataAnnotations;

namespace ActivityDiary.Web.Controllers
{
    public class HomeController : Controller
    {
        // Landing page for all visiters
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}