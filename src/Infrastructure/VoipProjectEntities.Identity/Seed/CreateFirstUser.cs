using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using VoipProjectEntities.Identity.Models;

namespace VoipProjectEntities.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<Customer> userManager)
        {
            var applicationUser = new Customer
            {
                CustomerName = "John",
                UserName = "johnsmith",
                Email = "john@test.com",
                EmailConfirmed = true,
                ISMigrated = true,
                CustomerTypeID = 2,
                ISTrialBalanceOpted = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "User123!@#");
                await userManager.AddToRoleAsync(applicationUser, "Administrator");
            }
        }
    }
}