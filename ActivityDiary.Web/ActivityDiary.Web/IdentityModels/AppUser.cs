using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ActivityDiary.Web.IdentityModels
{
    public class AppUser : IdentityUser
    {
        // Maybe some later I will add new properties for my user
        // public string MyExtraProperty { get; set; }
    }
}