using EduHome.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            //foreach (var role in Enum.GetValues(typeof(UserRoles)))
            //{
            //    if (!await roleManager.RoleExistsAsync(role.ToString()))
            //    {
            //        await roleManager.CreateAsync(new IdentityRole
            //        {
            //            Name = role.ToString(),

            //        });
            //    }
            //}

            var userDb = await userManager.FindByNameAsync("aziznijat1");
            if (userDb == null)
            {
                var user = new User
                {
                    Email = "aziznijat09@gmail.com",
                    UserName = "aziznijat1",
                    EmailConfirmed = true,
                    FullName="NijatAziz",
                };
                var result = await userManager.CreateAsync(user, "Admin1234!");
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }
                await userManager.AddToRoleAsync(user,"Admin");
            }
        }
    }
}
