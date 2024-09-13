using DAL.Models;
using Microsoft.AspNetCore.Identity;
using PermissionPro.PreDefined;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PermissionPro.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //var defaultUser = new ApplicationUser
            //{
            //    UserName = "basicuser@gmail.com",
            //    Email = "basicuser@gmail.com",
            //    DistrictName = "Basic",
            //    EmailConfirmed = true
            //};
            var defaultUser = new ApplicationUser
            {
                FirstName = "sulaman3",
                LastName = "khan3",
                UserName = "sudo3.admin@gmail.com",
                Email = "sudo3.admin@gmail.com",
                DistrictName = "Quetta",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qwert!123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
        }
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            var defaultUser = new ApplicationUser
            {
                FirstName = "sulaman",
                LastName = "khan",
                UserName = "sudo.admin@gmail.com",
                Email = "sudo.admin@gmail.com", 
                DistrictName = "Quetta",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Qwert!123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }
        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Products");
            await roleManager.AddPermissionClaim(adminRole, "Administrator");

            //await roleManager.AddPermissionClaim(adminRole, "CICIG");
            //await roleManager.AddPermissionClaim(adminRole, "CICIGTraining");
            //await roleManager.AddPermissionClaim(adminRole, "LIPTraining");
            //await roleManager.AddPermissionClaim(adminRole, "LIPAssetTransfer");
            //await roleManager.AddPermissionClaim(adminRole, "BSFGovt");
            //await roleManager.AddPermissionClaim(adminRole, "BSFPrivate");
            //await roleManager.AddPermissionClaim(adminRole, "GRM");
            //await roleManager.AddPermissionClaim(adminRole, "HTS");
            //await roleManager.AddPermissionClaim(adminRole, "HR");
            //await roleManager.AddPermissionClaim(adminRole, "IDO");
            //await roleManager.AddPermissionClaim(adminRole, "TVT");
            //await roleManager.AddPermissionClaim(adminRole, "MonitoringTool");
            //await roleManager.AddPermissionClaim(adminRole, "BusinessTraining");
            //await roleManager.AddPermissionClaim(adminRole, "EDP");
            //await roleManager.AddPermissionClaim(adminRole, "Reporting");
            //await roleManager.AddPermissionClaim(adminRole, "Maps");
        }
        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}
