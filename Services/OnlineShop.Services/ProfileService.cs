namespace OnlineShop.Services
{
    using System;
    using System.Text;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Interfaces;
    using OnlineShop.Data;
    using Microsoft.AspNetCore.Identity;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;
    using System.Linq;
    using OnlineShop.Common;

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext context;

        public ProfileService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string GenerateJwtToken(string userId, string userName, string sicret)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(sicret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptToken = tokenHandler.WriteToken(token);
            return encryptToken;
        }

        public IdentityUserRole<string> SetUserRole(ApplicationUser user)
        {
            this.GenerateRoles();
            var roleName = this.context.Users.Count() == 0 ?
                GlobalConstants.Roles.AdministratorRoleName : GlobalConstants.Roles.UserRoleName;
            var currectRole = this.context.Roles
                .Where(r => r.Name == roleName)
                .FirstOrDefault();

            var userRole = new IdentityUserRole<string>()
            {
                RoleId = currectRole.Id,
                UserId = user.Id,
            };
            return userRole;
        }

        private void GenerateRoles()
        {
            this.GenerateRole(GlobalConstants.Roles.AdministratorRoleName);
            this.GenerateRole(GlobalConstants.Roles.UserRoleName);
        }

        private async void GenerateRole(string roleName)
        {
            if (this.context.Roles
                .FirstOrDefault(r => r.Name == roleName) == null)
            {
                var role = new ApplicationRole(roleName);
                await this.context.Roles.AddAsync(role);
                this.context.SaveChanges();
            }
        }
    }
}
