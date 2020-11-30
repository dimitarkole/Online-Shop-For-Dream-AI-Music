﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.Extensions.Logging;
using OnlineShop.Common;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Web.Controllers
{
    [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
    public abstract class UserContoller : ApiController
    {
        protected UserContoller(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger) 
            : base(userManager, signInManager, logger)
        {
        }
    }
}
