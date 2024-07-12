using CleanArchitecture.Core.Enums;
using CleanArchitecture.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Mevcut rollerin oluşturulması
            await CreateRoleIfNotExists(roleManager, Roles.SuperAdmin);
            await CreateRoleIfNotExists(roleManager, Roles.Admin);
            await CreateRoleIfNotExists(roleManager, Roles.Moderator);
            await CreateRoleIfNotExists(roleManager, Roles.Basic);
            await CreateRoleIfNotExists(roleManager, Roles.Caretaker); 
        }

        private static async Task CreateRoleIfNotExists(RoleManager<IdentityRole> roleManager, Roles role)
        {
            if (!await roleManager.RoleExistsAsync(role.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
        }
    }
}