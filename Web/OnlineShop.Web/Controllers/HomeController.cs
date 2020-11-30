namespace OnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using OnlineShop.Data.Models;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : ApiController
    {
        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
        }

        [HttpGet]
        public ActionResult Index()
            => this.Ok();
    }
}
