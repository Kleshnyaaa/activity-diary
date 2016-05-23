using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ActivityDiary.Web.IdentityModels
{
    public class UsersService
    {
        private HttpContextBase HttpContext { get; set; }

        public UsersService(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        private IAuthenticationManager AuthenticationMange
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        // How to define or use RoleManeger?

        public bool LogIn(string userAlias, string password) // userAlias - user's Name or Email
        {
            // Just use code example from UsersController.LogIn to verify and login user
        }
    }
}