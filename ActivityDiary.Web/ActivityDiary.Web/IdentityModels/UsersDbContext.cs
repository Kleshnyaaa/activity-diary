using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ActivityDiary.Web.IdentityModels
{
    public class UsersDbContext : IdentityDbContext<AppUser>
    {
        public UsersDbContext() : base ("ActivityDiaryDB") { }
    }
}