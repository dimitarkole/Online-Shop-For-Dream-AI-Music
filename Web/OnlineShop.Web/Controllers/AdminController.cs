namespace OnlineShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.Extensions.Logging;
    using OnlineShop.Common;
    using OnlineShop.Data.Models;

    [Authorize(Roles = GlobalConstants.Roles.AdministratorRoleName)]
    public abstract class AdminController : ApiController
    {
        protected AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
        }
    }
}
