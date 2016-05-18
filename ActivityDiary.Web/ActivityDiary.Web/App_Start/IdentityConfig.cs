using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivityDiary.Web.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace ActivityDiary.Web
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new UsersDbContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            // В примере не было последнего String параметра. Разобраться, что за метод, как используется и какой нужно передавать параметр
            app.CreatePerOwinContext<RoleManager<AppRole>>(
                (options, context) => new RoleManager<AppRole>(new RoleStore<AppRole>(context.Get<UsersDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Users/LogIn")
            });
        }
    }
}