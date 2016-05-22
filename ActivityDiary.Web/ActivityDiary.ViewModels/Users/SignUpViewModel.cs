using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ActivityDiary.ViewModels.Users
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(255, ErrorMessage = "Name length should be between 5 and 255 characters"), MinLength(5, ErrorMessage = "Name is too short")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Please check email format")]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please set Password")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Password length should be between 5 and 255 characters"), MinLength(5, ErrorMessage = "Password is too short")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirmed password are not equal")]
        public string ConfirmPassword { get; set; }
    }
}
