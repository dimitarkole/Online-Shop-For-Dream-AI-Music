namespace OnlineShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Interfaces;
    using OnlineShop.Web.ViewModels.CategoriesModel;

    using static OnlineShop.Common.GlobalConstants;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(
            ICategoryService categoryService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
            => this.Ok(this.categoryService.All<CategoryViewModel>());

        [HttpGet("{id}")]
        public IActionResult Get(string id)
            => this.Ok(this.categoryService.GetById<CategoryDetailModel>(id));

        [Authorize(Roles = Roles.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.categoryService.Create(model);
            return this.StatusCode(StatusCodes.Status201Created);
        }

        [Authorize(Roles = Roles.AdministratorRoleName)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, CategoryEditInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.categoryService.Update(id, model);
            return this.Ok();
        }

        [Authorize(Roles = Roles.AdministratorRoleName)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.categoryService.Delete(id);
            return this.Ok();
        }
    }
}
