using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Entity
{
   public class DelonAppIdentityData
    {
        //public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        //{

        //    SeedUser(userManager, roleManager);

        //    _ = SeedRolesAsync(userManager, roleManager);
        //}

        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new ApplicationRole(DelonRoles.Basic.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(DelonRoles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(DelonRoles.HROfficer1.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(DelonRoles.HROfficer2.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(DelonRoles.FinanceOfficer1.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(DelonRoles.FinanceOfficer2.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@delon.com",
                Email = "admin@delon.com",
                EmailConfirmed = true
            };
            if(userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if(user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Delon@AdHr_2021");
                    await userManager.AddToRoleAsync(defaultUser, DelonRoles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, DelonRoles.FinanceOfficer1.ToString());
                    await userManager.AddToRoleAsync(defaultUser, DelonRoles.FinanceOfficer2.ToString());
                    await userManager.AddToRoleAsync(defaultUser, DelonRoles.SuperAdmin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, DelonRoles.HROfficer1.ToString());
                    await userManager.AddToRoleAsync(defaultUser, DelonRoles.HROfficer2.ToString());
        
                }
            }
        }

        //public static void SeedUser(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        //{
        //    if (userManager.FindByEmailAsync("admin@delon.com").Result == null) 
        //    {
        //        ApplicationUser applicationUser = new ApplicationUser();
        //        applicationUser.UserName = "admin@delon.com";
        //        applicationUser.Email = "admin@delon.com";
        //        applicationUser.EmailConfirmed = true;

        //        //Result of an Identity Operation
        //        IdentityResult identityResult = userManager.CreateAsync(applicationUser, "Delon@AdHr_2021").Result;


        //        if (identityResult.Succeeded)
        //        {
        //            userManager.AddToRoleAsync(applicationUser, DelonRoles.Basic.ToString());
        //            userManager.AddToRoleAsync(applicationUser, DelonRoles.SuperAdmin.ToString());
        //            userManager.AddToRoleAsync(applicationUser, DelonRoles.HROfficer1.ToString());
        //            userManager.AddToRoleAsync(applicationUser, DelonRoles.HROfficer2.ToString());
        //            userManager.AddToRoleAsync(applicationUser, DelonRoles.FinanceOfficer1.ToString());
        //            userManager.AddToRoleAsync(applicationUser, DelonRoles.FinanceOfficer2.ToString());
        //        }
        //    }

        //}


        //public static void SeedRole(RoleManager<ApplicationRole> roleManager)
        //{
        //    if (!roleManager.RoleExistsAsync("Super Admin").Result)
        //    {
        //        ApplicationRole applicationRole = new ApplicationRole();
        //        applicationRole.Name = "Super Admin";

        //        IdentityResult identityResult = roleManager.CreateAsync(applicationRole).Result;
        //    }
        //}


    }
}
