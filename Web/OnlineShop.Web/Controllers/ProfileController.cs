namespace OnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Interfaces;
    using OnlineShop.Web.Infrastucture.Configurations;
    using OnlineShop.Web.Infrastucture.Extensions;
    using OnlineShop.Web.ViewModels.IdentityModels;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProfileController : ApiController
    {
        private readonly IProfileService profileService;

        public ProfileController(
          IProfileService profileService,
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<LogoutModel> logger)
          : base(userManager, signInManager, logger)
        {
            this.profileService = profileService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApplicationUser>> Create(IdentityCreateInputModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Username,
            };

            user.Roles.Add(this.profileService.SetUserRole(user));

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors.Select(e => e.Description).ToList());
            }

            return user;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApplicationUser>> Login(LoginInputModel model, [FromServices] IOptions<JwtSettings> settings)
        {
            var jwtToken = await this.userManager.Authenticate(model.Username, model.Password, settings.Value);

            if (jwtToken == null)
            {
                return this.BadRequest("Username or password is incorrect.");
            }

            return new JsonResult(jwtToken);
        }
    }
}
