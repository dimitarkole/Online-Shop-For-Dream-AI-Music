namespace OnlineShop.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OnlineShop.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public interface IProfileService
    {
        string GenerateJwtToken(string userId, string userName, string sicret);

        IdentityUserRole<string> SetUserRole(ApplicationUser user);
    }
}
