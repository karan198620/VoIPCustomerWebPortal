using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using VoipProjectEntities.Identity;
using VoipProjectEntities.Identity.Models;

namespace VoipProjectEntities.API.IntegrationTests.Base
{
    public class SeedIdentity
    {
        private readonly IdentityDbContext _identityDbContext;

        public SeedIdentity(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }
        public async void SeedUsers()
        {
            PasswordHasher<Customer> passwordHasher = new PasswordHasher<Customer>();

            Customer admin = new Customer()
            {
                CustomerName = "John",
                UserName = "johnsmith",
                NormalizedUserName = "JOHNSMITH",
                Email = "john@test.com",
                NormalizedEmail = "JOHN@TEST.COM",
                EmailConfirmed = true,
                ISTrialBalanceOpted = true,
                ISMigrated = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CustomerTypeID=2

            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "User123!@#");
            await _identityDbContext.Users.AddAsync(admin);

            Customer viewer = new Customer()
            {
                CustomerName = "APOORV",
                ISTrialBalanceOpted = true,
                ISMigrated = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CustomerTypeID = 2,
                UserName = "apoorv",
                NormalizedUserName = "APOORV",
                Email = "apoorv@test.com",
                NormalizedEmail = "APOORV@TEST.COM",
                EmailConfirmed = true
            };
            viewer.PasswordHash = passwordHasher.HashPassword(viewer, "User123!@#");
            await _identityDbContext.Users.AddAsync(viewer);

            await _identityDbContext.SaveChangesAsync();
        }

        public async void SeedUserRoles()
        {
            var roles = await _identityDbContext.Roles.ToListAsync();
            var users = await _identityDbContext.Users.ToListAsync();

            for (int i = 0; i < roles.Count; i++)
            {
                var userRole = new IdentityUserRole<string>() { RoleId = roles[i].Id, UserId = users[i].Id };
                await _identityDbContext.UserRoles.AddAsync(userRole);
            }
            await _identityDbContext.SaveChangesAsync();
        }
    }
}
