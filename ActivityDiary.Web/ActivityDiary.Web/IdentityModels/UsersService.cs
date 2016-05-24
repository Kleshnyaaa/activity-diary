using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        // How to define or use RoleManeger?

        public bool LogIn(string userAlias, string password) // userAlias - user's Name or Email
        {
            // Just use code example from UsersController.LogIn to verify and login user
            AppUser user;

            user = UserManager.Find(userAlias, password);
            if (user == null)
            {
                user = UserManager.FindByEmail(userAlias);
                if (user == null)
                {
                    return false;
                }
                else
                {
                    string tmpUserName = user.UserName;
                    user = UserManager.Find(tmpUserName, password);
                }
            }

            // On current moment user contains real user (or method is returned false)
            // set cookies
            ClaimsIdentity claim = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignOut();
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, claim);

            return true;
        }

        public bool RegisterUser(string userName, string email, string password)
        {
            IdentityResult result = UserManager.Create(new AppUser
            {
                UserName = userName,
                Email = email
            }, password);

            if (result.Succeeded)
            {
                LogIn(userName, password);
            }
            // Write error in the log, if there is some problems when create new user

            return result.Succeeded;
        }
    }
}