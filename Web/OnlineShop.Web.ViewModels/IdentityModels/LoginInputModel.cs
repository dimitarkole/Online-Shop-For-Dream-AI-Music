namespace OnlineShop.Web.ViewModels.IdentityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using OnlineShop.Common;

    public class LoginInputModel
    {
        [MinLength(GlobalConstants.UsernameMinLength)]
        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [MinLength(GlobalConstants.PasswordMinLength)]
        [MaxLength(GlobalConstants.PasswordMaxLength)]
        public string Password { get; set; }
    }
}
