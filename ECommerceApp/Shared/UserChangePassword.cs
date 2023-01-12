using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared
{
    public class UserChangePassword
    {
        [Required, StringLength(100, MinimumLength =6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "Vänligt ange samma lösenord!")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
