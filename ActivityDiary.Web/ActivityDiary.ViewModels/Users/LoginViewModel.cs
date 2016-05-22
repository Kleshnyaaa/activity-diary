using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ActivityDiary.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter Name or Email")]
        public string NameOrEmail { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }
}
